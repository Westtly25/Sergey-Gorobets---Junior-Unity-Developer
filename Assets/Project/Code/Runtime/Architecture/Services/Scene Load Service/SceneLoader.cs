using Zenject;
using Cysharp.Threading.Tasks;
using Assets.Project.Code.Runtime.Architecture.Services.Assets_Management;

namespace Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service
{
    public sealed class SceneLoader : ISceneLoader
    {
        private readonly IAssetProvider assetProvider;

        [Inject]
        public SceneLoader(IAssetProvider assetProvider)
        {
            this.assetProvider = assetProvider;
        }

        public async UniTask LoadSceneAsync(string address) =>
            await assetProvider.LoadSceneAsync(address);

        public async UniTask UnloadSceneAsync(string address) =>
            await assetProvider.UnloadSceneAsync(address);
    }
}