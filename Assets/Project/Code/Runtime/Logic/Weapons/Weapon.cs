using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Shooting;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ShootFromPoint shootPoint;

        [Header("Config Data")]
        [SerializeField]
        private WeaponConfig weaponConfig;

        public ShootFromPoint ShootPoint => shootPoint;
        public WeaponConfig WeaponConfig => weaponConfig;
    }
}