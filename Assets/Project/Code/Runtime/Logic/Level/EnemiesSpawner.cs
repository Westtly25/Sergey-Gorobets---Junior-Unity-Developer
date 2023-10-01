using Assets.Project.Code.Runtime.Logic.Characters.Enemies;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public sealed class EnemiesSpawner : Spawner<Enemy>
    {
        private Pool<Enemy> pool;

        public EnemiesSpawner(SpawnPoint[] spawnPoints, EnemyFactory factory) : base(spawnPoints)
        {
            this.factory = factory;
        }

        public override void Spawn()
        {
        }
    }
}