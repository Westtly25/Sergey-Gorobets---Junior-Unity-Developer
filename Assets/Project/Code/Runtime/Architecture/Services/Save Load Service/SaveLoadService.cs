using System;
using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface;
using static Assets.Project.Code.Shared.SharedConstants;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service
{
    public sealed class SaveLoadService : ISaveLoadService
    {
        [Header("CONFIGURATION DATA")]
        private string filePath;
        private readonly string fileName = AppFileConfigs.SavesFileName;

        [Header("COMPONENTS")]
        private GameData gameData;

        [SerializeField]
        private readonly List<IPersistentDataListener> saveDataContracts;

        public GameData SaveData => gameData;

        [Header("Injected Services")]
        private readonly DiContainer diContainer;
        private readonly IFileDataHandler filDataHandler;

        [Inject]
        public SaveLoadService(DiContainer diContainer,
                               IFileDataHandler fileDataHandler)
        {
            this.diContainer = diContainer;
            this.filDataHandler = fileDataHandler;
        }

        public async UniTask Initialize()
        {
            filePath = CreateFilePath();

            List<IPersistentDataListener> dependencies = diContainer.ResolveAll<IPersistentDataListener>();

            for (int i = 0; i < dependencies.Count; i++)
                saveDataContracts.Add(dependencies[i]);

            await UniTask.CompletedTask;
        }

        public void CreateNewSave() =>
            gameData = new();

        public async UniTask LoadAsync()
        {
            string loaded = await filDataHandler.ReadFileAsync(filePath);

            if (string.IsNullOrEmpty(loaded) || string.IsNullOrWhiteSpace(loaded))
                CreateNewSave();
            else gameData = JsonUtility.FromJson<GameData>(loaded);

            for (int i = 0; i < saveDataContracts.Count; i++)
                saveDataContracts[i].LoadData(gameData);
        }

        public async UniTask SaveAsync()
        {
            for (int i = 0; i < saveDataContracts.Count; i++)
                saveDataContracts[i].SaveData(ref gameData);

            string toSave = JsonUtility.ToJson(gameData);

            await filDataHandler.WriteFileAsync(filePath, fileName, toSave);
        }

        private string CreateFilePath()
        {
#if UNITY_EDITOR
            return Application.dataPath + AppFileConfigs.SavesFilesFolder;
#elif UNITY_ANDROID
            return Application.persistentDataPath + AppFileConfigs.SavesFilesFolder;
#endif
        }
    }
}