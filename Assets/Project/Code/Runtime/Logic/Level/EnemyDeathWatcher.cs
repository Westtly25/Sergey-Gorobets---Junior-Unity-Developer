using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public sealed class EnemyDeathWatcher
    {
        private List<Enemy> activeEnemies;

        public event Action AllEnemiesDead;

        [Header("Injected Components")]
        private readonly LevelData levelData;

        [Inject]
        public EnemyDeathWatcher(LevelData levelData) =>
            this.levelData = levelData;

        public void Initialize()
        {
            activeEnemies = levelData.Enemies;

            SubscribeAll();
        }

        private void SubscribeAll()
        {
            if (activeEnemies == null)
                return;

            for (int i = 0; i < activeEnemies.Count; i++)
                activeEnemies[i].Health.OnDead += OnEnemyDead;
        }

        private void UnSubscribeAll()
        {
            if (activeEnemies == null)
                return;

            for (int i = 0; i < activeEnemies.Count; i++)
                activeEnemies[i].Health.OnDead -= OnEnemyDead;
        }

        public void OnEnemyDead()
        {
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                if (activeEnemies[i].Health.HealthValue > 0)
                    return;
            }

            AllEnemiesDead?.Invoke();
        }
    }
}