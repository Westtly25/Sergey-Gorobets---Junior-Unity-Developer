using System;
using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public class AmmoEntry
    {
        [SerializeField]
        private AmmoType bulletType;
        [SerializeField, Min(0)]
        private int stock;
        [SerializeField, Range(0, 9999)]
        private int maxCapacity;

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

        public int MaxCapacity
        {
            get => maxCapacity; 
            set=> maxCapacity = value;
        }
    }
}