using System;
using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    [Serializable]
    public sealed class AmmoEntry
    {
        [SerializeField]
        private AmmoType bulletType;
        [SerializeField, Min(0)]
        private int stock;
        [SerializeField, Min(9999)]
        private int maxCapacity = 9999;

        public AmmoEntry() { }

        public AmmoEntry(AmmoType bulletType, int stock)
        {
            this.bulletType = bulletType;
            this.stock = stock;
        }

        public AmmoType BulletType
        {
            get => bulletType;
            set => bulletType = value;
        }

        public int Stock
        {
            get => stock;
            set => stock = value;
        }

        public int MaxCapacity =>
            maxCapacity; 
    }
}