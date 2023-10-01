using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public abstract class Spawner<T> where T : MonoBehaviour
    {
        protected IFactory<T> factory;
        protected SpawnPoint[] points;

        public Spawner(SpawnPoint[] points)
        {
            this.points = points;
        }

        public virtual void Spawn()
        {

        }
    }
}