using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Inventory;
using Assets.Project.Code.Runtime.Logic.UI_Components;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class GameplayWindow : Window
    {
        [SerializeField]
        private InventoryView inventoryView;

        [SerializeField]
        private HealthPresenter healthPresenter;

        private IWindowsHandler windowsHandler;
        private IAmmoInventory ammoInventory;
        private IWeaponsInventory inventoryHandler;
        private Hero hero;

        public override void Initialize()
        {
            windowsHandler = diContainer.Resolve<IWindowsHandler>();
            ammoInventory = diContainer.Resolve<IAmmoInventory>();
            inventoryHandler = diContainer.Resolve<IWeaponsInventory>();
            //hero = diContainer.Resolve<Hero>();

            //healthPresenter.Initialize(hero.Health);
            inventoryView.Initialize(inventoryHandler, ammoInventory);
        }
    }
}