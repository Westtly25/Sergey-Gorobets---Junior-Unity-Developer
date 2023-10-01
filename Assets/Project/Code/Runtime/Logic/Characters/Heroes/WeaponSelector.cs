using Zenject;
using UnityEngine;
using System.Collections.Generic;
using Assets.Project.Code.Runtime.Logic.Weapons;
using Assets.Project.Code.Runtime.Logic.Shooting;
using Assets.Project.Code.Runtime.Logic.Inventory;

namespace Assets.Project.Code.Runtime.Logic.Characters.Heroes
{
    public sealed class WeaponSelector : MonoBehaviour
    {
        [SerializeField]
        private Transform rightHand;

        [SerializeField]
        private List<Weapon> weapons = new(3);

        [SerializeField]
        private Weapon activeWeapon;

        [Header("Injected")]
        private WeaponsInventory inventoryHandler;
        private DiContainer diContainer;

        [Header("Components")]
        private RaycastShoot shoot;
        private HeroAnimator animator;

        [Inject]
        public void Construct(WeaponsInventory inventoryHandler, DiContainer diContainer)
        {
            this.inventoryHandler = inventoryHandler;
            this.diContainer = diContainer;
        }

        private void Awake() =>
            InitializeComponents();

        private void InitializeComponents()
        {
            shoot = GetComponent<RaycastShoot>();
            animator = GetComponent<HeroAnimator>();
        }

        private void OnEnable() =>
            inventoryHandler.InventoryUpdated += OnInventoryUpdated;

        private void OnDisable() =>
            inventoryHandler.InventoryUpdated -= OnInventoryUpdated;

        private void OnInventoryUpdated(int id, WeaponConfig weapon) =>
            OnEquip(id, weapon);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SelectWeapon(0);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                SelectWeapon(1);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                SelectWeapon(2);
        }

        private void SelectWeapon(int index)
        {
            if (weapons[index] != null)
            {
                DisableActiveWeapon();
                activeWeapon = weapons[index];
                weapons[index].gameObject.SetActive(true);
                shoot.SetWeapon(activeWeapon);
                animator.SetAnimatorController(activeWeapon.WeaponConfig.AnimatorController);
            }
        }

        private void OnEquip(int id, WeaponConfig weaponConfig)
        {
            if (weapons[id] == null)
            {
                Weapon weapon = SpawnWeapon(weaponConfig);
                weapons[id] = weapon;

                DisableActiveWeapon();

                activeWeapon = weapon;
                activeWeapon.gameObject.SetActive(true);
                shoot.SetWeapon(activeWeapon);
                animator.SetAnimatorController(activeWeapon.WeaponConfig.AnimatorController);
                return;
            }
        }

        private Weapon SpawnWeapon(WeaponConfig weaponConfig)
        {
            Weapon weapon = Instantiate(weaponConfig.Weapon);
            weapon.transform.SetParent(rightHand, true);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
            weapon.transform.localRotation = Quaternion.Euler(-90, -90, 0);
            return weapon;
        }

        private void DisableActiveWeapon()
        {
            if (activeWeapon != null)
                activeWeapon.gameObject.SetActive(false);
        }
    }
}
