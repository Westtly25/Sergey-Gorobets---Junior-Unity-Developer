using Zenject;
using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Weapons;
using Assets.Project.Code.Runtime.Logic.Inventory;
using Assets.Project.Code.Runtime.Logic.Camera_Logic;

namespace Assets.Project.Code.Runtime.Logic.Shooting
{
    public sealed class RaycastShoot : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private Weapon activeWeapon;

        [HideInInspector]
        private Camera mainCamera;

        private float lastShootTime;
        private Vector3 directionTo;

        [Header("Injected Components")]
        private AmmoInventory ammoInventory;

        [Inject]
        public void Construct(AmmoInventory ammoInventory, CameraController cameraController)
        {
            this.ammoInventory = ammoInventory;
            this.mainCamera = cameraController.GetComponent<Camera>();
        }

        private void Awake() =>
            mainCamera = Camera.main;

        private void Update()
        {
            if (activeWeapon == null)
                return;

            if (Input.GetMouseButtonDown(0) ||
                Input.GetMouseButton(0))
                PerformShoot();
        }

        public void SetWeapon(Weapon activeWeapon)
        {
            this.activeWeapon = activeWeapon;
            ResetShootTimeCooldown();
        }

        public void PerformShoot()
        {
            if (!IsReadyToShoot())
                return;

            if (ammoInventory.TrySpend(activeWeapon.WeaponConfig.AmmoType, 1))
            {
                CreateRaycast();
                PerformShootEffect();
            }

            ResetShootTimeCooldown();
        }

        private bool IsReadyToShoot() =>
            lastShootTime + activeWeapon.WeaponConfig.Cooldown < Time.time;

        private void CreateRaycast()
        {
            Ray ray = mainCamera.ScreenPointToRay(ScreenCenter());

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask))
            {
                Collider hitCollider = hitInfo.collider;

                directionTo = (hitInfo.point - activeWeapon.ShootPoint.transform.position).normalized;

                if (hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(activeWeapon.WeaponConfig.Damage);
                }

                PerformHitEffect(hitInfo.point);
            }
            else directionTo = ray.direction;
        }

        private ParticleSystem shootVisualEffect;
        private ParticleSystem hitVisualEffect;

        private void PerformShootEffect()
        {
            if (shootVisualEffect == null)
            {
                shootVisualEffect = Instantiate(activeWeapon.WeaponConfig.ShootVfx);
                shootVisualEffect.transform.SetParent(activeWeapon.ShootPoint.transform, true);
            }

            shootVisualEffect.transform.localPosition = activeWeapon.ShootPoint.transform.localPosition;
            shootVisualEffect.Play();
        }

        private void PerformHitEffect(Vector3 at)
        {
            if (hitVisualEffect == null)
                hitVisualEffect = Instantiate(activeWeapon.WeaponConfig.ShootVfx);

            hitVisualEffect.transform.position = at;
            hitVisualEffect.Play();
        }

        private void ResetShootTimeCooldown() =>
            lastShootTime = Time.time;

        private Vector3 ScreenCenter() =>
            new Vector2(Screen.width / 2, Screen.height / 2);
    }
}