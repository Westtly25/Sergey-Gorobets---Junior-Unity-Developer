using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Assets.Project.Code.Runtime.Architecture.Services.Assets_Management
{
    public sealed class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> completedCache = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> handles = new();

        public AssetProvider() { }

        public async UniTask Initialize() =>
            await Addressables.InitializeAsync();

        public Task<GameObject> InstantiateAsync(string address) =>
            Addressables.InstantiateAsync(address).Task;

        public Task<GameObject> InstantiateAsync(string address, Vector3 at) =>
            Addressables.InstantiateAsync(address, at, Quaternion.identity).Task;

        public async UniTask LoadSceneAsync(string address)
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(address, LoadSceneMode.Additive, false);
            completedCache.Add(address, handle);

            SceneInstance scene = await handle.Task;

            if (handle.IsDone)
                await scene.ActivateAsync();
        }

        public async UniTask UnloadSceneAsync(string address)
        {
            if (completedCache.TryGetValue(address, out AsyncOperationHandle handle))
            {
                await Addressables.UnloadSceneAsync(handle);
                completedCache.Remove(address);
            }

            await UniTask.CompletedTask;
        }

        public async Task<T> LoadAsync<T>(AssetReference assetReference) where T : class
        {
            if (completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithCacheOnComplete(
                Addressables.LoadAssetAsync<T>(assetReference),
                cacheKey: assetReference.AssetGUID);
        }

        public async Task<T> LoadAsync<T>(string address) where T : class
        {
            if (completedCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithCacheOnComplete(
                Addressables.LoadAssetAsync<T>(address),
                cacheKey: address);
        }

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in handles.Values)
                foreach (AsyncOperationHandle handle in resourceHandles)
                    Addressables.Release(handle);

            completedCache.Clear();
            handles.Clear();
        }

        private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
        {
            handle.Completed += completeHandle => 
                                completedCache[cacheKey] = completeHandle;

            AddHandle(cacheKey, handle);

            return await handle.Task;
        }
    
        private void AddHandle<T>(string cacheKey, AsyncOperationHandle<T> handle) where T : class
        {
            if (!handles.TryGetValue(cacheKey, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                handles[cacheKey] = resourceHandles;

                resourceHandles.Add(handle);
            }
        }
    }
}