using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Characters.Heroes
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour
    {
        private readonly int Speed = Animator.StringToHash("Speed");
        private readonly int Attack = Animator.StringToHash("SimpleAttack");
        private readonly int DieHash = Animator.StringToHash("Die");
        private readonly int IdleHash = Animator.StringToHash("Idl");
        private readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField]
        private Animator animator;


        private void Awake() =>
            animator = GetComponent<Animator>();

        public void SetAnimatorController(AnimatorOverrideController animatorController)
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