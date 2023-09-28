using Cysharp.Threading.Tasks;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface
{
    public interface IFileDataHandler
    {
        UniTask<string> ReadFileAsync(string filePath);
        UniTask WriteFileAsync(string filePath, string fileName, string text);
    }
}