using Assets.Project.Code.Runtime.Logic.Weapons;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public interface IAmmoInventory
    {
        void Add(AmmoClipConfig ammoConfig);
        AmmoEntry Get(AmmoType ammoType);
        void Spend(AmmoType ammoType, int amount);
    }
}