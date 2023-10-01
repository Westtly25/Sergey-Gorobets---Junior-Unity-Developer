using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Shooting;
using Assets.Project.Code.Runtime.Logic.Inventory;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;

namespace Assets.Project.Code.Runtime.Logic.Characters.Heroes
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(HeroAnimator))]
    [RequireComponent(typeof(WeaponsCollector))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(MovementController))]
    public class Hero : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private Health health;
        [SerializeField]
        private HeroConfig heroConfig;
        [SerializeField]
        private MovementController controller;
        [SerializeField]
        private HeroAnimator animator;

        public Health Health => health;

        private void Awake()
        {
            controller = GetComponent<MovementController>();
            animator = GetComponent<HeroAnimator>();
        }

        private void Start()
        {
            health.SetData(heroConfig.Health, heroConfig.Health);
            controller.Initialize(heroConfig);

            health.OnDead += OnDead;
        }

        public void ApplyDamage(float damage) =>
            health.AddDamage(damage);

        private void OnDead()
        {
            animator.PlayDeath();
            health.OnDead -= OnDead;
        }
    }
}