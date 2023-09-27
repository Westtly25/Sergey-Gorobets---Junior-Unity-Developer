﻿using System.IO;
using System.Text;
using Cysharp.Threading.Tasks;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service
{
    public sealed class FileDataHandler : IFileDataHandler
    {
        public FileDataHandler() { }

        public async UniTask<string> ReadFileAsync(string filePath)
        {
            CheckDirectory(filePath);

            using FileStream sourceStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            using StreamReader reader = new(sourceStream);
            StringBuilder sb = new();

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public async UniTask WriteFileAsync(string filePath, string text)
        {
            CheckDirectory(filePath);

            using FileStream destinationStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            using StreamWriter writer = new(destinationStream);
            await writer.WriteLineAsync(text);
        }

        private void CheckDirectory(string filePath)
        {
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
        }
    }
}