using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Shooting;
using Assets.Project.Code.Runtime.Logic.Inventory;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;

namespace Assets.Project.Code.Runtime.Logic.Characters.Heroes
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(WeaponsCollector))]
    [RequireComponent(typeof(HeroAnimator))]
    [RequireComponent(typeof(HeroController))]
    [RequireComponent(typeof(CharacterController))]
    public class Hero : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private Health health;
        [SerializeField]
        private HeroConfig heroConfig;
        [SerializeField]
        private HeroController movement;

        public Health Health => health;

        private void Awake()
        {
            health.SetData(heroConfig.Health, heroConfig.Health);
            movement.Initialize(heroConfig);
        }

        public void ApplyDamage(float damage) =>
            health.AddDamage(damage);
    }
}