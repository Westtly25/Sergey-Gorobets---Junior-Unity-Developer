using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Shooting;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    [CreateAssetMenu(fileName = "New-ammo-config-so", menuName = "Shooter / Core / Weapons / Bullets / Ammo Config")]
    public class AmmoConfig : ScriptableObject
    {
        [SerializeField]
        private AmmoType bulletType;
        [SerializeField, Range(10, 200)]
        private float speed;
        [SerializeField, Range(1, 100)]
        private int damage;
        [SerializeField]
        private ParticleSystem hitVfx;
        [SerializeField]
        private Projectile projectile;

        public AmmoType BulletType => bulletType;
        public float Speed => speed;
        public int Damage => damage;
        public ParticleSystem HitVfx => hitVfx;
        public Projectile Projectile => projectile;
    }
}