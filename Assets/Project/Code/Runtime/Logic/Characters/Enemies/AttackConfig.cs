using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [CreateAssetMenu(fileName = "Enemy-attack-config", menuName = "Shooter / Core / Characters / Enemy / Attack Config")]
    public class AttackConfig : ScriptableObject
    {
        [SerializeField, Min(0)]
        private float cooldown = 0.5f;
        [SerializeField, Min(0.1f)]
        private float range = 1f;
        [SerializeField, Min(1)]
        private float damage = 20;
        [SerializeField]
        private LayerMask layerMask;

        public float Cooldown => cooldown; 
        public float Range => range; 
        public float Damage => damage;
        public LayerMask LayerMask => layerMask;
    }
}