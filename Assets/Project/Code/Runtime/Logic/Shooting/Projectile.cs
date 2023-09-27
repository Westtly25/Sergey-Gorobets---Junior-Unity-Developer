using Zenject;
using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Shooting
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class Projectile : MonoBehaviour, IPoolable<Vector3, IMemoryPool>
    {
        [SerializeField]
        private AmmoConfig bulletConfig;
        [SerializeField]
        private Rigidbody rigBody;

        private ParticleSystem impactVisualEffect;

        private IMemoryPool pool;

        private void Awake()
        {
            rigBody = rigBody != null ?
                      rigBody :  GetComponent<Rigidbody>();
        }

        public void Launch() =>
            rigBody.velocity = transform.forward * bulletConfig.Speed;

        public void OnSpawned(Vector3 from, IMemoryPool pool)
        {
            this.pool = pool;

            Launch();
        }

        public void OnDespawned()
        {
            if (pool != null)
                pool.Despawn(this);
        }
    }
}