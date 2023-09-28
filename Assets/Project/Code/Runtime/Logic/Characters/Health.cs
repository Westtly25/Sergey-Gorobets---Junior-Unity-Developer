using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters
{
    [Serializable]
    public sealed class Health : Attribute
    {
        [SerializeField, Min(-1)]
        private float health;
        [SerializeField]
        private float maxHealth;
        [SerializeField]
        private bool isDead;

        public float HealthValue => health;
        public float MaxHealth => maxHealth;
        public bool IsDead => isDead;

        public event Action<float> HealthChanged;
        public event Action OnDead;

        public void SetData(float health, float maxHealth)
        {
            this.health = health;
            this.maxHealth = maxHealth;
        }

        public void AddDamage(float damage)
        {
            health -= damage;
            HealthChanged?.Invoke(health);

            if (health <= 0)
            {
                isDead = true;
                OnDead?.Invoke();
            }
        }
    }
}