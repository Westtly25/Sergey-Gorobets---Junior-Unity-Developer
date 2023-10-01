using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public sealed class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private InventorySlotView[] inventorySlotViews;

        private IAmmoInventory ammoInventory;
        private IWeaponsInventory weaponInventory;

        private void Awake()
        {
            if (inventorySlotViews == null)
                inventorySlotViews = GetComponentsInChildren<InventorySlotView>();
        }

        private void OnDisable() =>
            UnSubscribe();

        public void Initialize(IWeaponsInventory weaponInventory, IAmmoInventory ammoInventory)
        {
            this.weaponInventory = weaponInventory;
            this.ammoInventory = ammoInventory;

            Subscribe();
        }

        public void Subscribe()
        {
            weaponInventory.InventoryUpdated += OnSlotDataUpdated;
            ammoInventory.AmmoChanged += OnAmmoChanged;
        }

        private void UnSubscribe()
        {
            weaponInventory.InventoryUpdated -= OnSlotDataUpdated;
            ammoInventory.AmmoChanged -= OnAmmoChanged;
        }

        private void OnSlotDataUpdated(int id, WeaponConfig weapon)
        {
            int amount = ammoInventory.Get(weapon.AmmoType).Stock;
            inventorySlotViews[id].SetData(weapon.Icon, amount);
        }

        private void OnAmmoChanged(AmmoEntry ammoEntry)
        {
            foreach (var item in weaponInventory.WeaponsList)
            {
                int amount = ammoInventory.Get(item.Value.AmmoType).Stock;
                inventorySlotViews[item.Key].SetData(amount);
            }
        }
    }
}