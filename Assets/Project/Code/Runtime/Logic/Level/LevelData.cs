using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    [Serializable]
    public sealed class LevelData
    {
        [SerializeField]
        private List<Enemy> enemies;
        [SerializeField]
        private SpawnPoint[] spawnPointEnemy;
        [SerializeField]
        private SpawnPoint spawnPointHero;

        public List<Enemy> Enemies => enemies;
        public SpawnPoint[] SpawnPointEnemy => spawnPointEnemy;
        public SpawnPoint SpawnPointHero => spawnPointHero;
    }
}