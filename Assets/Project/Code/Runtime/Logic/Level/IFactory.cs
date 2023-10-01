using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public interface IFactory<T>
    {
        UniTask<T> CreateAsync(string address);
    }
}