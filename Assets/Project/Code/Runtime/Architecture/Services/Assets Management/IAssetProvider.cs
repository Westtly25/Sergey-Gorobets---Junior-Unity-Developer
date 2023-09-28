using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Assets.Project.Code.Runtime.Architecture.Services.Assets_Management
{
    public interface IAssetProvider
    {
        UniTask Initialize();
        Task<GameObject> InstantiateAsync(string address);
        Task<GameObject> InstantiateAsync(string address, Vector3 at);
        UniTask LoadSceneAsync(string address);
        UniTask UnloadSceneAsync(string address);
        Task<T> LoadAsync<T>(AssetReference assetReference) where T : class;
        Task<T> LoadAsync<T>(string address) where T : class;
        void CleanUp();
    }
}