using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [CreateAssetMenu(fileName = "New-enemy-config", menuName = "Shooter / Core / Characters / Enemy / Enemy Config")]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField, Range(1, 20f)]
        public float AggroZoneSize;

        [SerializeField, Range(1, 20f)]
        public float StopDistance;
    }
}