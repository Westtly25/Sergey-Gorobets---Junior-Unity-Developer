using Zenject;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Assets_Management;
using Assets.Project.Code.Runtime.Architecture.Services.Scene_Load_Service;

namespace Assets.Project.Code.Runtime.Architecture.Bootstrap
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<FileDataHandler>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<SceneLoader>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<SaveLoadService>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<BootstrapFlow>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }
    }
}
