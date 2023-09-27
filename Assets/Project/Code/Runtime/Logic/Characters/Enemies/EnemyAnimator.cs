using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [RequireComponent(typeof(Animator))]
    public sealed class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Attack = Animator.StringToHash("SimpleAttack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField]
        private Animator animator;

        private void Awake() =>
            animator = GetComponent<Animator>();

        public void Pause() =>
            animator.speed = 0;

        public void UnPause() =>
            animator.speed = 1;

        public void PlayDeath() =>
            animator.SetTrigger(Die);

        public void PlayAttack() =>
            animator.SetBool(Attack, true);

        public void StopAttack() =>
            animator.SetBool(Attack, false);

        public void Move(float speed)
        {
            animator.SetBool(IsMoving, true);
            animator.SetFloat(Speed, speed);
        }

        public void StopMove()
        {
            animator.SetBool(IsMoving, false);
            animator.SetFloat(Speed, 0);
        }
    }
}
