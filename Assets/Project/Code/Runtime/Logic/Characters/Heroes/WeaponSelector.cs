using System;
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

        [Header("Components")]
        private RaycastShoot shoot;
        private HeroAnimator animator;

        [Inject]
        public void Construct(WeaponsInventory inventoryHandler) =>
            this.inventoryHandler = inventoryHandler;

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
            Equip(id, weapon);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (weapons[0] != null)
                {
                    DisableActiveWeapon();

                    activeWeapon = weapons[0];
                    weapons[0].gameObject.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (weapons[1] != null)
                {
                    DisableActiveWeapon();
                    activeWeapon = weapons[1];
                    weapons[1].gameObject.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (weapons[2] != null)
                {
                    DisableActiveWeapon();
                    activeWeapon = weapons[2];
                    weapons[2].gameObject.SetActive(true);
                }
            }
        }

        private void Equip(int id, WeaponConfig weaponConfig)
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
            weapon.transform.SetParent(rightHand.transform, true);
            weapon.transform.localPosition = rightHand.localPosition;
            weapon.transform.localRotation = rightHand.localRotation;
            return weapon;
        }

        private void DisableActiveWeapon()
        {
            if (activeWeapon != null)
                activeWeapon.gameObject.SetActive(false);
        }
    }
}
