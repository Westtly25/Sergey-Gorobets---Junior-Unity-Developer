using Zenject;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;

namespace Assets.Project.Code.Runtime.Architecture.Bootstrap
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FileDataHandler>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<SaveLoadService>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<InputReader>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }
    }
}
