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
        public GameData SaveData => gameData;

        [Header("Injected Services")]
        private readonly DiContainer diContainer;
        private readonly IFileDataHandler filDataHandler;

        [Inject]
        public SaveLoadService(IFileDataHandler fileDataHandler) =>
            this.filDataHandler = fileDataHandler;

        public async UniTaskVoid Initialize()
        {
            filePath = CreateFilePath();

            await UniTask.CompletedTask;
        }

        public void CreateNewSave() =>
            gameData = new();

        public async UniTask LoadAsync()
        {
            string loaded = await filDataHandler.ReadFileAsync(filePath, fileName);

            if (string.IsNullOrEmpty(loaded))
                CreateNewSave();
            else gameData = JsonUtility.FromJson<GameData>(loaded);
        }

        public async UniTask SaveAsync()
        {
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