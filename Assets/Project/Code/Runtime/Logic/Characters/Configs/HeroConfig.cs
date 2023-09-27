using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [CreateAssetMenu(fileName = "New-hero-config", menuName = "Shooter / Core / Characters / Hero Config")]
    public class HeroConfig : CharacterConfig
    {
        [SerializeField, Range(1f, 1000f)]
        public float RotateSpeed;
    }
}