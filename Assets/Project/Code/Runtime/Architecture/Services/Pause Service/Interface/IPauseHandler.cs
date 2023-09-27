using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Scripts.Runtime.Architecture.Pause_system
{
    public interface IPauseHandler
    {
        bool IsPaused { get; }
        void Register(IPauseListener listener);
        void UnRegister(IPauseListener listener);
        void SetPaused(bool isPaused);
        UniTask Initialize();
        void SetPauseSimpleWay(bool isPaused);
    }
}