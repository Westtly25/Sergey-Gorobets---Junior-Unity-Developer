using Assets.Project.Code.Runtime.Logic.Weapons;
using System;
using System.Collections.Generic;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public interface IWeaponsInventory
    {
        Dictionary<int, WeaponConfig> WeaponsList { get; }
        event Action<int, WeaponConfig> InventoryUpdated;
        void Add(WeaponConfig weapon);
    }
}