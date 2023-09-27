using Cysharp.Threading.Tasks;

namespace Assets.Code.Runtime.Services.Windows
{
    public interface IWindowsHandler
    {
        UniTask Initialize();
        void Show<T>() where T : Window;
        void ShowPopUp<T>() where T : Window;
        void Pop();
    }
}