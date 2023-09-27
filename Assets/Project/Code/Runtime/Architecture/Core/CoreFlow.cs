using Zenject;
using UnityEngine;
using Assets.Code.Runtime.Services.Windows;
using Assets.Project.Code.Runtime.Logic.Level;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Windows.Windows_Types;
using Assets.Project.Code.Scripts.Runtime.Architecture.Pause_system;

namespace Assets.Project.Code.Runtime.Architecture.Core
{
    public sealed class CoreFlow : IInitializable
    {
        private readonly ISaveLoadService saveLoadService;
        private readonly IWindowsHandler windowsHandler;
        private readonly DeathProgressWatcher enemyDeathProgressWatcher;
        private readonly IPauseHandler pauseHandler;
        private readonly Hero hero;

        [Inject]
        public CoreFlow(ISaveLoadService saveLoadService,
                        IWindowsHandler windowsHandler,
                        DeathProgressWatcher enemyDeathProgressWatcher,
                        IPauseHandler pauseHandler,
                        Hero hero)
        {
            this.saveLoadService = saveLoadService;
            this.windowsHandler = windowsHandler;
            this.enemyDeathProgressWatcher = enemyDeathProgressWatcher;
            this.pauseHandler = pauseHandler;
            this.hero = hero;
        }

        public async void Initialize()
        {
            await windowsHandler.Initialize();
            await pauseHandler.Initialize();
            enemyDeathProgressWatcher.Initialize();

            windowsHandler.Show<GameplayWindow>();
            Cursor.visible = false;

            Subscribe();

            pauseHandler.SetPauseSimpleWay(false);
        }

        private void Subscribe()
        {
            hero.Health.OnDead += OnLose;
            enemyDeathProgressWatcher.AllEnemiesDead += OnWin;
        }

        private void OnWin()
        {
            pauseHandler.SetPauseSimpleWay(true);
            Cursor.visible = true;
            windowsHandler.Show<WinWindow>();
        }

        private void OnLose()
        {
            pauseHandler.SetPauseSimpleWay(true);
            Cursor.visible = true;
            windowsHandler.Show<LoseWindow>();
        }
    }
}