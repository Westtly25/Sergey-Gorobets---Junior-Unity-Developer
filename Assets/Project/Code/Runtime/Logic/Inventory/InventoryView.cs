using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public sealed class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private InventorySlotView[] inventorySlotViews;

        private IAmmoInventory ammoInventory;
        private IWeaponsInventory inventoryHandler;

        private void OnDisable() =>
            UnSubscribe();

        public void Initialize(IWeaponsInventory weaponInventory, IAmmoInventory ammoInventory)
        {
            this.inventoryHandler = weaponInventory;
            this.ammoInventory = ammoInventory;

            Subscribe();
        }

        private void Subscribe() =>
            inventoryHandler.InventoryUpdated += OnSlotDataUpdated;

        private void UnSubscribe() =>
            inventoryHandler.InventoryUpdated += OnSlotDataUpdated;

        private void OnSlotDataUpdated(int id, WeaponConfig weapon)
        {
            int amount = ammoInventory.Get(weapon.Ammo.BulletType).Stock;
            inventorySlotViews[id].SetData(weapon.Icon, amount);
        }
    }
}