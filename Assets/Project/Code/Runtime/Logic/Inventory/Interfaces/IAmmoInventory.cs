using Assets.Project.Code.Runtime.Logic.Weapons;
using System;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public interface IAmmoInventory
    {
        event Action<AmmoEntry> AmmoChanged;

        void Add(AmmoClipConfig ammoConfig);
        AmmoEntry Get(AmmoType ammoType);
        void Spend(AmmoType ammoType, int amount);
        bool IsAmmoEnoughForShoot(AmmoType ammoType);
    }
}