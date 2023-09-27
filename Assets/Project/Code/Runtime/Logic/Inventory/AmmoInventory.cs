using System;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    [Serializable]
    public sealed class AmmoInventory : IAmmoInventory
    {
        private Dictionary<AmmoType, AmmoEntry> ammoList;

        public AmmoInventory()
        {
            ammoList = new Dictionary<AmmoType, AmmoEntry>(3)
            {
                { AmmoType.Pistol, new AmmoEntry(AmmoType.Pistol, 50, 9999) },
                { AmmoType.Rifle, new AmmoEntry(AmmoType.Rifle, 100, 9999) },
                { AmmoType.Shotgun, new AmmoEntry(AmmoType.Shotgun, 50, 9999) }
            };
        }

        public void Add(AmmoClipConfig ammoConfig)
        {
            AmmoEntry ammoToStack = Get(ammoConfig.BulletType);

            if (ammoToStack != null)
            {
                ammoToStack.Stock += ammoConfig.Stock;
                return;
            }

            AmmoEntry ammoToAdd = new AmmoEntry(ammoConfig.BulletType, ammoConfig.Stock, ammoConfig.MaxCapacity);
            ammoList.Add(ammoToAdd.BulletType, ammoToAdd);
        }

        public void Spend(AmmoType ammoType, int amount)
        {
            AmmoEntry ammoToSpend = Get(ammoType);

            if (ammoToSpend != null && ammoToSpend.Stock > 0)
                ammoToSpend.Stock -= amount;
        }

        public AmmoEntry Get(AmmoType ammoType)
        {
            if (ammoList.TryGetValue(ammoType, out AmmoEntry ammo))
                return ammo;

            return null;
        }

        public bool IsAmmoEnoughForShoot(AmmoType ammoType) =>
            Get(ammoType).Stock > 0;
    }
}