using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface;
using Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service;
using Assets.Project.Code.Shared;
using UnityEngine.Playables;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class MenuWindow : Window
    {
        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Button quiteButton;

        [SerializeField]
        private TextMeshProUGUI winsText;

        [SerializeField]
        private TextMeshProUGUI losesText;

        private IWindowsHandler windowsHandler;
        private ISaveLoadService saveLoadService;
        private ISceneLoader sceneLoader;

        public override void Initialize()
        {
            windowsHandler = diContainer.TryResolve<IWindowsHandler>();
            saveLoadService = diContainer.TryResolve<ISaveLoadService>();
            sceneLoader = diContainer.TryResolve<ISceneLoader>();
        }

        public override void Show()
        {
            base.Show();

            winsText.text = saveLoadService.SaveData.WinCount.ToString();
            losesText.text = saveLoadService.SaveData.LoseCount.ToString();
        }

        public override void Subscribe()
        {
            playButton?.onClick.AddListener(Play);
            quiteButton?.onClick.AddListener(Quite);
        }

        public override void UnSubscribe()
        {
            playButton?.onClick.RemoveListener(Play);
            quiteButton?.onClick.RemoveListener(Quite);
        }

        private async void Play()
        {
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.MetaScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.CoreScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
        }

        private void Quite() =>
            windowsHandler.ShowPopUp<QuiteWindow>();
    }
}