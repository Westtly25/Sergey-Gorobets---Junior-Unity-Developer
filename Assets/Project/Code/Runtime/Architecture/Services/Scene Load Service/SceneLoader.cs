using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service
{
    public sealed class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(string address)
        {

            await UniTask.CompletedTask;
        }

        public async UniTask UnloadSceneAsync(string address)
        {

            await UniTask.CompletedTask;
        }
    }
}