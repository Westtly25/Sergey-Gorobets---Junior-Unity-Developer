using Zenject;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public sealed class WeaponsCollector : MonoBehaviour
    {
        private WeaponsInventory inventoryHandler;

        [Inject]
        public void Constructor(WeaponsInventory inventoryHandler) =>
            this.inventoryHandler = inventoryHandler;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CollectableItem>(out CollectableItem collectable))
            {
                inventoryHandler.Add(collectable.Weapon);
                collectable.gameObject.SetActive(false);
            }
        }
    }
}