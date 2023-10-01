using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;
using Assets.Project.Code.Runtime.Architecture.Services.Assets_Management;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public sealed class HeroFactory : IFactory<Hero>
    {
        private readonly DiContainer container;
        private readonly IAssetProvider provider;

        [Inject]
        public HeroFactory(DiContainer container, IAssetProvider provider)
        {
            this.container = container;
            this.provider = provider;
        }

        public async UniTask<Hero> CreateAsync(string address)
        {
            GameObject asset = await provider.LoadAsync<GameObject>(address);
            Hero hero = container.InstantiateComponent<Hero>(asset);
            return hero;
        }
    }
}