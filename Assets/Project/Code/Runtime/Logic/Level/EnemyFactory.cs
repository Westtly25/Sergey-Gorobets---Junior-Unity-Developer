using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;
using Assets.Project.Code.Runtime.Architecture.Services.Assets_Management;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public sealed class EnemyFactory : IFactory<Enemy>
    {
        private readonly DiContainer container;
        private readonly IAssetProvider provider;

        [Inject]
        public EnemyFactory(DiContainer container, IAssetProvider provider)
        {
            this.container = container;
            this.provider = provider;
        }

        public async UniTask<Enemy> CreateAsync(string address)
        {
            GameObject asset = await provider.LoadAsync<GameObject>(address);
            Enemy enemy = container.InstantiateComponent<Enemy>(asset);
            return enemy;
        }
    }
}