using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Characters;

namespace Assets.Project.Code.Runtime.Logic.UI_Components
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField]
        private CustomProgressBar healthBar;

        [SerializeField]
        private Health health;

        private void Awake()
        {
            if (TryGetComponent<CustomProgressBar>(out CustomProgressBar progressBar))
                this.healthBar = progressBar;
        }

        public void Subscribe() =>
            health.HealthChanged += OnHealthChanged;

        public void UnSubscribe() =>
            health.HealthChanged -= OnHealthChanged;

        public void Initialize(Health health)
        {
            this.health = health;
            health.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            float progress = value / health.MaxHealth;
            healthBar.Change(progress);
        }
    }
}