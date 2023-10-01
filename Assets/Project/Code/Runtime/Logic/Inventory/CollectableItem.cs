using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    [RequireComponent(typeof(CapsuleCollider))]
    public sealed class CollectableItem : MonoBehaviour
    {
        [SerializeField]
        private WeaponConfig weapon;

        public WeaponConfig Weapon => weapon;
    }
}