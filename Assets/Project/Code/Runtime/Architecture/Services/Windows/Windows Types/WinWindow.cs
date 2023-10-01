using UnityEngine;
using UnityEngine.UI;
using Assets.Project.Code.Shared;
using Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class WinWindow : Window
    {
        [SerializeField]
        public Button restartButton;

        [SerializeField]
        private Button exiteButton;

        private ISceneLoader sceneLoader;

        public override void Initialize()
        {
            this.sceneLoader = diContainer.Resolve<ISceneLoader>();
        }

        public override void Subscribe()
        {
            restartButton?.onClick.AddListener(Restart);
            exiteButton?.onClick.AddListener(Exite);
        }

        public override void UnSubscribe()
        {
            restartButton?.onClick.RemoveListener(Restart);
            exiteButton?.onClick.RemoveListener(Exite);
        }

        private async void Restart()
        {
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.CoreScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.CoreScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
        }

        private async void Exite()
        {
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.CoreScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.MetaScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
        }
    }
}
