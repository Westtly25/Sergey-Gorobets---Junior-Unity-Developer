using System;
using UnityEngine.AI;
using System.Threading.Tasks;
using Assets.Project.Code.Runtime.Logic.Fsm;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies.States
{
    public class DeathState : IState<Enemy>
    {
        private readonly EnemyAnimator animator;
        private readonly NavMeshAgent agent;

        public Enemy Initializer { get; private set; }

        public DeathState(Enemy enemy,
                          EnemyAnimator animator,
                          NavMeshAgent agent)
        {
            this.Initializer = enemy;
            this.animator = animator;
            this.agent = agent;
        }

        public async void OnEnter()
        {
            agent.isStopped = true;
            animator.PlayDeath();

            await Task.Delay(TimeSpan.FromSeconds(2f));

            Initializer.gameObject.SetActive(false);
        }

        public void OnExit()
        {
        }

        public void OnRun()
        {
        }
    }
}
