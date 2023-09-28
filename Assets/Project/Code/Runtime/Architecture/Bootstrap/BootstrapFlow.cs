using Zenject;
using Assets.Project.Code.Shared;
using Assets.Project.Code.Runtime.Architecture.Services.Assets_Management;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service;
using Assets.Code.Runtime.Services.Windows;
using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Runtime.Architecture.Bootstrap
{
    public sealed class BootstrapFlow : IInitializable
    {
        private readonly IAssetProvider assetProvider;
        private readonly ISaveLoadService saveLoadService;
        private readonly SceneLoader sceneLoader;
        private readonly InputReader inputReader;

        [Inject]
        public BootstrapFlow(IAssetProvider assetProvider,
                             ISaveLoadService saveLoadService,
                             SceneLoader sceneLoader,
                             InputReader inputReader)
        {
            this.assetProvider = assetProvider;
            this.saveLoadService = saveLoadService;
            this.sceneLoader = sceneLoader;
            this.inputReader = inputReader;
        }

        public async void Initialize()
        {
            await assetProvider.Initialize();
            saveLoadService.Initialize();
            await saveLoadService.LoadAsync();

            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesAddresses.MetaScene);
            await sceneLoader.UnloadSceneAsync(SharedConstants.ScenesAddresses.LoadScene);
        }
    }
}