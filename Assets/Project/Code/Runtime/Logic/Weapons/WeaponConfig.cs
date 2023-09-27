using UnityEngine;
using UnityEditor.Animations;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    [CreateAssetMenu(fileName = "New-activeWeapon-config-so", menuName = "Shooter / Core / Weapons / Weapon Config")]
    public class WeaponConfig : ItemConfig
    {
        [Header("Base Data")]
        [SerializeField]
        private Weapon prefab;
        [SerializeField]
        private AnimatorController animatorController;

        [SerializeField, Min(0)]
        private float cooldown;

        [Header("Ammo")]
        [SerializeField]
        private AmmoConfig ammo;

        [Header("Visual Effect")]
        [SerializeField]
        private ParticleSystem shootVfx;

        public Weapon Weapon => prefab;
        public float Cooldown => cooldown;
        public AmmoConfig Ammo => ammo;
        public ParticleSystem ShootVfx => shootVfx;
        public AnimatorController AnimatorController => animatorController;
    }
}