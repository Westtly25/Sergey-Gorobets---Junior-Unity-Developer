using System;
using Zenject;
using System.IO;
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

        [SerializeField, Min(0), Range(0, 12)]
        private byte currentId = 0;

        [Header("COMPONENTS")]
        private GameData gameData;

        [SerializeField]
        private readonly List<IPersistentDataListener> saveDataContracts;

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
            CreateFilePath();

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

            gameData = JsonUtility.FromJson<GameData>(loaded);

            for (int i = 0; i < saveDataContracts.Count; i++)
                saveDataContracts[i].LoadData(gameData);
        }

        public async UniTask SaveAsync()
        {
            for (int i = 0; i < saveDataContracts.Count; i++)
                saveDataContracts[i].SaveData(ref gameData);

            string toSave = JsonUtility.ToJson(gameData);

            await filDataHandler.WriteFileAsync(filePath, toSave);
        }

        private string CreateFilePath() =>
            Application.persistentDataPath + AppFileConfigs.SavesFilesFolder;
    }
}