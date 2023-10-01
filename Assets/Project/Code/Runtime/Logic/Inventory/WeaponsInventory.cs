using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    [Serializable]
    public sealed class WeaponsInventory : IWeaponsInventory
    {
        [SerializeField]
        private Dictionary<int, WeaponConfig> weaponsList;

        public Dictionary<int, WeaponConfig> WeaponsList => weaponsList;
        public event Action<int, WeaponConfig> InventoryUpdated;

        public WeaponsInventory()
        {
            weaponsList = new Dictionary<int, WeaponConfig>(3)
            {
                { 0, null },
                { 1, null },
                { 2, null },
            };
        }

        public void Add(WeaponConfig weapon)
        {
            foreach (var item in weaponsList)
            {
                if (item.Value == null)
                {
                    weaponsList[item.Key] = weapon;
                    InventoryUpdated?.Invoke(item.Key, weapon);

#if UNITY_EDITOR
                    Debug.Log($"Add item to Weapon Inventory {weapon.name}");
#endif
                    return;
                }
            }
        }
    }
}