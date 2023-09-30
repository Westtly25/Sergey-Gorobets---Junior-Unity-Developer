using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    [CreateAssetMenu(fileName = "New-activeWeapon-config-so", menuName = "Shooter / Core / Weapons / Weapon Config")]
    public class WeaponConfig : ItemConfig
    {
        [Header("Base Data")]
        [SerializeField]
        private Weapon prefab;
        [SerializeField]
        private AnimatorOverrideController animatorController;

        [SerializeField, Range(0.1f, 5f)]
        private float cooldown;

        [Header("Ammo")]
        [SerializeField]
        private AmmoType ammoType;
        [SerializeField, Range(1, 100)]
        private int damage;

        [Header("Visual Effect")]
        [SerializeField]
        private ParticleSystem shootVfx;
        [SerializeField]
        private ParticleSystem hitVfx;

        public Weapon Weapon => prefab;
        public float Cooldown => cooldown;
        public AmmoType AmmoType => ammoType;
        public float Damage => damage;
        public ParticleSystem ShootVfx => shootVfx;
        public ParticleSystem HitVfx => hitVfx;
        public AnimatorOverrideController AnimatorController => animatorController;
    }
}