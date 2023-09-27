using UnityEngine;
using UnityEditor.Animations;

namespace Assets.Project.Code.Runtime.Logic.Characters.Heroes
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour
    {
        [SerializeField]
        public Animator animator;

        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("SimpleAttack");
        private static readonly int DieHash = Animator.StringToHash("Die");
        private static readonly int IdleHash = Animator.StringToHash("Idl");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private void Awake() =>
            animator = GetComponent<Animator>();

        public void SetAnimatorController(AnimatorController animatorController)
        {
            if (animatorController == null)
                return;

            animator.runtimeAnimatorController = animatorController;
        }

        public void PauseAnimator(bool isPaused) =>
            animator.speed = isPaused ? 0 : 1;

        public void PlayAttack() =>
            animator.SetTrigger(Attack);

        public void PlayDeath() =>
            animator.SetTrigger(DieHash);

        public void ResetToIdle() =>
            animator.Play(IdleHash);

        public void StopMove()
        {
            animator.SetBool(IsMoving, false);
            animator.SetFloat(Speed, 0);
        }

        public void Move(float speed)
        {
            animator.SetBool(IsMoving, true);
            animator.SetFloat(Speed, speed);
        }
    }
}