using System;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public interface IAmmoInventory
    {
        event Action<AmmoEntry> AmmoChanged;

        void Add(AmmoType ammo, int amount);
        AmmoEntry Get(AmmoType ammoType);
        void Spend(AmmoType ammoType, int amount);
    }
}