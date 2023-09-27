using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service
{
    public interface ISaveLoadService
    {
        GameData SaveData { get; }
        UniTask Initialize();
        UniTask LoadAsync();
        UniTask SaveAsync();
        void CreateNewSave();
    }
}