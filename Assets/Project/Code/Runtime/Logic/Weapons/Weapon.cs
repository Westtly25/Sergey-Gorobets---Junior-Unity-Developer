using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Shooting;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ShootPoint shootPoint;

        [Header("Config Data")]
        [SerializeField]
        private WeaponConfig weaponConfig;

        public ShootPoint ShootPoint => shootPoint;
        public WeaponConfig WeaponConfig => weaponConfig;
    }
}