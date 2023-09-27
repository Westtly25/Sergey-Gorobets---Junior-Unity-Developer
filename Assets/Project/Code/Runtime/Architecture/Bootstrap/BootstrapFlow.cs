using Zenject;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service;
using Assets.Project.Code.Shared;

namespace Assets.Project.Code.Runtime.Architecture.Bootstrap
{
    public sealed class BootstrapFlow : IInitializable
    {
        private readonly ISaveLoadService saveLoadService;
        private readonly SceneLoader sceneLoader;
        private readonly InputReader inputReader;

        [Inject]
        public BootstrapFlow(ISaveLoadService saveLoadService,
                             SceneLoader sceneLoader,
                             InputReader inputReader)
        {
            this.saveLoadService = saveLoadService;
            this.sceneLoader = sceneLoader;
            this.inputReader = inputReader;
        }

        public async void Initialize()
        {

            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesConstants.LoadScene);
            await sceneLoader.LoadSceneAsync(SharedConstants.ScenesConstants.MetaScene);
        }
    }
}