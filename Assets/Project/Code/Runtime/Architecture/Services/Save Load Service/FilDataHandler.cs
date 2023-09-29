using System.IO;
using System.Text;
using Cysharp.Threading.Tasks;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service
{
    public sealed class FileDataHandler : IFileDataHandler
    {
        public FileDataHandler() { }

        public async UniTask<string> ReadFileAsync(string directoryPath, string fileName)
        {
            CreateDirectory(directoryPath);
            CreateFile(directoryPath, fileName);

            using FileStream sourceStream = new(Path.Combine(directoryPath, fileName), FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            using StreamReader reader = new(sourceStream);
            StringBuilder sb = new();

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public async UniTask WriteFileAsync(string directoryPath, string fileName, string text)
        {
            using FileStream destinationStream = new(Path.Combine(directoryPath, fileName), FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            using StreamWriter writer = new(destinationStream);
            await writer.WriteLineAsync(text);
        }

        public void CreateDirectory(string filePath)
        {
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
        }

        public void CreateFile(string filePath, string fileName)
        {
            string fullPath = Path.Combine(filePath, fileName);

            if (!File.Exists(fullPath))
                File.Create(fullPath);
        }
    }
}