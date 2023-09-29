using UnityEngine;
using UnityEngine.UI;
using Assets.Project.Code.Shared;
using Assets.Code.Runtime.Services.Windows;
using Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service;

namespace Assets.Project.Code.Runtime.Architecture.Services.Windows.Windows_Types
{
    public sealed class LoseWindow : Window
    {
        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private Button exitButton;

        private ISceneLoader sceneLoader;

        public override void Initialize()
        {
            this.sceneLoader = diContainer.Resolve<ISceneLoader>();
        }

        public override void Subscribe()
        {
            restartButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(Exit);
        }

        public override void UnSubscribe()
        {
            restartButton.onClick.RemoveListener(Restart);
            exitButton.onClick.RemoveListener(Exit);
        }

        private async void Restart()
        {
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.CoreScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
        }

        private async void Exit()
        {
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.CoreScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.MetaScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
        }
    }
}