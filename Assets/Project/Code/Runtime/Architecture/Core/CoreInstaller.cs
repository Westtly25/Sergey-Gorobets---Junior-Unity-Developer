using Zenject;
using UnityEngine;
using Assets.Code.Runtime.Services.Windows;
using Assets.Project.Code.Runtime.Logic.Level;
using Assets.Project.Code.Runtime.Logic.Inventory;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;
using Assets.Project.Code.Runtime.Architecture.Services.Windows.Windows_Types;
using Assets.Project.Code.Runtime.Logic.Camera_Logic;
using Assets.Project.Code.Scripts.Runtime.Architecture.Pause_system;

namespace Assets.Project.Code.Runtime.Architecture.Core
{
    public sealed class CoreInstaller : MonoInstaller
    {
        [SerializeField]
        private Hero hero;

        [SerializeField]
        private CameraController cameraController;

        [SerializeField]
        private LevelData levelData;

        [SerializeField]
        private GameplayWindow gameplayWindow;
        [SerializeField]
        private LoseWindow loseWindow;
        [SerializeField]
        private WinWindow winWindow;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PauseHandler>()
                     .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CameraController>()
                     .FromInstance(cameraController).AsSingle();

            Container.BindInterfacesAndSelfTo<LevelData>()
                     .FromInstance(levelData).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<EnemyDeathWatcher>()
                     .FromNew().AsSingle().WithArguments(levelData);

            Container.BindInterfacesAndSelfTo<Hero>()
                     .FromInstance(hero).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<AmmoInventory>()
                     .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<WeaponsInventory>()
                     .FromNew().AsSingle().NonLazy();

            BindWindows();

            Container.BindInterfacesAndSelfTo<CoreFlow>()
                     .FromNew().AsSingle().NonLazy();
        }

        private void BindWindows()
        {
            Container.Bind<Window>().To<GameplayWindow>()
                     .FromInstance(gameplayWindow)
                     .AsSingle()
                     .NonLazy();

            Container.Bind<Window>().To<LoseWindow>()
                     .FromInstance(loseWindow)
                     .AsSingle()
                     .NonLazy();

            Container.Bind<Window>().To<WinWindow>()
                     .FromInstance(winWindow)
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<WindowsHandler>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(new Window[] { gameplayWindow, loseWindow, winWindow });
        }
    }
}