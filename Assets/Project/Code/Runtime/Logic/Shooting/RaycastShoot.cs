using System;
using Zenject;
using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;
using Assets.Project.Code.Runtime.Logic.Inventory;

namespace Assets.Project.Code.Runtime.Logic.Shooting
{
    public sealed class RaycastShoot : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField, Space(4)]
        private LayerMask layerMask;

        [SerializeField, Space(4)]
        private Weapon activeWeapon;

        [SerializeField]
        private Camera mainCamera;

        private float lastShootTime;
        private Vector3 directionTo;

        [Header("Injected Components")]
        private AmmoInventory ammoInventory;

        [Inject]
        public void Construct(AmmoInventory ammoInventory)
        {
            this.ammoInventory = ammoInventory;
        }

        private void Awake() =>
            mainCamera = Camera.main;

        private void Update()
        {
            if (activeWeapon == null)
                return;

            if (Input.GetMouseButtonDown(0))
                PerformShoot();
        }

        public void SetWeapon(Weapon activeWeapon) =>
            this.activeWeapon = activeWeapon;

        public void PerformShoot()
        {
            if (!ammoInventory.IsAmmoEnoughForShoot(activeWeapon.WeaponConfig.Ammo.BulletType))
                return;

            CreateRaycast();
            SpawnProjectile();
            PerformEffects();
            ammoInventory.Spend(activeWeapon.WeaponConfig.Ammo.BulletType, 1);
        }

        public void CreateRaycast()
        {
            Ray ray = mainCamera.ScreenPointToRay(ScreenCenter());

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask))
            {
                Collider hitCollider = hitInfo.collider;

                directionTo = (hitInfo.point - activeWeapon.ShootPoint.transform.position).normalized;

                if (hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    Debug.DrawLine(activeWeapon.ShootPoint.CachedPosition, hitInfo.point, Color.green, 10f);
                    damageable.ApplyDamage(activeWeapon.WeaponConfig.Ammo.Damage);
                }
            }
            else directionTo = ray.direction;
        }

        private ParticleSystem shootVisualEffect;

        private void PerformEffects()
        {
            if (shootVisualEffect == null)
            {
                shootVisualEffect = Instantiate(activeWeapon.WeaponConfig.ShootVfx);
                shootVisualEffect.transform.SetParent(activeWeapon.ShootPoint.transform, true);
                shootVisualEffect.transform.localPosition = activeWeapon.ShootPoint.transform.localPosition;
            }

            shootVisualEffect.Play();
        }

        private void SpawnProjectile()
        {
            Projectile projectile = Instantiate(activeWeapon.WeaponConfig.Ammo.Projectile,
                                                activeWeapon.ShootPoint.transform.position,
                                                Quaternion.LookRotation(directionTo, Vector3.up));
            projectile.Launch();
        }

        private Vector3 ScreenCenter() =>
            new Vector2(Screen.width / 2, Screen.height / 2);
    }
}