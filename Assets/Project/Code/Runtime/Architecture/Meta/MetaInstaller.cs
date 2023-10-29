using Zenject;
using UnityEngine;
using Assets.Code.Runtime.Services.Windows;
using Assets.Project.Code.Runtime.Architecture.Links_Service;

namespace Assets.Project.Code.Runtime.Architecture.Meta
{
    public sealed class MetaInstaller : MonoInstaller
    {
        [SerializeField]
        private MenuWindow menuWindow;

        [SerializeField]
        private QuiteWindow quiteWindow;

        public override void InstallBindings()
        {
            BindWindows();

            Container.BindInterfacesAndSelfTo<LinksProvider>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<MetaFlow>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }

        private void BindWindows()
        {
            Container.Bind<Window>().To<MenuWindow>()
                     .FromInstance(menuWindow)
                     .AsSingle()
                     .NonLazy();

            Container.Bind<Window>().To<QuiteWindow>()
                     .FromInstance(quiteWindow)
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<WindowsHandler>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(new Window[] { menuWindow, quiteWindow });
        }
    }
}
