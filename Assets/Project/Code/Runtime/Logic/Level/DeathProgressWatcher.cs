using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;
using Assets.Project.Code.Scripts.Runtime.Architecture.Pause_system;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public sealed class DeathProgressWatcher
    {
        private List<Enemy> enemies;

        public event Action AllEnemiesDead;

        [Header("Injected Components")]
        private readonly LevelData levelData;
        private readonly IPauseHandler pauseHandler;

        [Inject]
        public DeathProgressWatcher(LevelData levelData, IPauseHandler pauseHandler)
        {
            this.levelData = levelData;
            this.pauseHandler = pauseHandler;
        }

        public void Initialize()
        {
            enemies = levelData.Enemies;

            SubscribeAll();
        }

        private void SubscribeAll()
        {
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Health.OnDead += OnDead;
        }

        public void OnDead()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Health.HealthValue > 0)
                    return;
            }

            AllEnemiesDead?.Invoke();
        }
    }
}