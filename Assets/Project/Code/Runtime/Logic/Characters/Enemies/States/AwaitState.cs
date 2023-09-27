using Assets.Project.Code.Runtime.Logic.Fsm;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies.States
{
    public sealed class AwaitState : IState<Enemy>
    {
        private readonly EnemyAnimator animator;

        public Enemy Initializer { get; private set; }

        public AwaitState(Enemy enemy,
                          EnemyAnimator animator)
        {
            this.Initializer = enemy;
            this.animator = animator;
        }

        public void OnEnter()
        {
            animator.StopMove();
        }

        public void OnExit()
        {
        }

        public void OnRun()
        {
        }
    }
}
