using UnityEngine;
using UnityEditor.Animations;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField, Range(0.5f, 2f)]
        public float WalkSpeed;

        [SerializeField, Range(2f, 5f)]
        public float RunSpeed;

        [SerializeField, Range(50f, 200f)]
        public float Health;

        [SerializeField]
        public AnimatorController defaultAnimator;
    }
}