using Assets.Project.Code.Runtime.Logic.Weapons;
using System;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public interface IWeaponsInventory
    {
        event Action<int, WeaponConfig> InventoryUpdated;
        void Add(WeaponConfig weapon);
    }
}