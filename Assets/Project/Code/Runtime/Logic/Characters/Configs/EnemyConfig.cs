using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [CreateAssetMenu(fileName = "New-enemy-config", menuName = "Shooter / Core / Characters / Enemy / Enemy Config")]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField, Range(0.1f, 50f)]
        public float AttackDamage;

        [SerializeField, Range(1, 20f)]
        private float aggroZoneSize;

        [SerializeField, Range(1, 20f)]
        private float stopDistance;
    }
}