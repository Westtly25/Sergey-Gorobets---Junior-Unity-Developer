using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string address);
        UniTask UnloadSceneAsync(string address);
    }
}