﻿using UnityEngine;
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

        private void OnDisable()
        {
            health.HealthChanged -= OnHealthChanged;
        }

        public void Initialize(Health health)
        {
            this.health = health;
            health.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            Debug.Log("Health changed in UI");
            float progress = value / health.MaxHealth;
            healthBar.Change(progress);
        }
    }
}