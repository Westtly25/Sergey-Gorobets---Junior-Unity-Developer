using System;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    [Serializable]
    public sealed class AmmoInventory : IAmmoInventory
    {
        private Dictionary<AmmoType, AmmoEntry> ammoList;

        public event Action<AmmoEntry> AmmoChanged;

        public AmmoInventory()
        {
            ammoList = new Dictionary<AmmoType, AmmoEntry>(3)
            {
                { AmmoType.Pistol, new AmmoEntry(AmmoType.Pistol, 50) },
                { AmmoType.Rifle, new AmmoEntry(AmmoType.Rifle, 100) },
                { AmmoType.Shotgun, new AmmoEntry(AmmoType.Shotgun, 50) }
            };
        }

        public void Add(AmmoType ammo, int amount)
        {
            AmmoEntry ammoToStack = Get(ammo);

            if (ammoToStack != null)
            {
                ammoToStack.Stock += amount;
                return;
            }

            AmmoEntry ammoToAdd = new AmmoEntry(ammo, amount);
            ammoList.Add(ammoToAdd.BulletType, ammoToAdd);
        }

        public void Spend(AmmoType ammoType, int amount)
        {
            AmmoEntry ammoToSpend = Get(ammoType);

            if (ammoToSpend != null && ammoToSpend.Stock > amount)
            {
                ammoToSpend.Stock -= amount;
                AmmoChanged?.Invoke(ammoToSpend);
            }
        }

        public bool TrySpend(AmmoType ammoType, int amount)
        {
            AmmoEntry ammoToSpend = Get(ammoType);

            if (ammoToSpend != null && ammoToSpend.Stock > amount)
            {
                ammoToSpend.Stock -= amount;
                AmmoChanged?.Invoke(ammoToSpend);
                return true;
            }

            return false;
        }

        public AmmoEntry Get(AmmoType ammoType)
        {
            if (ammoList.TryGetValue(ammoType, out AmmoEntry ammo))
                return ammo;

            return null;
        }
    }
}