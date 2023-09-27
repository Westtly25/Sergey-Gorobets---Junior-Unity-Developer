using UnityEngine;
using UnityEngine.AI;
using Assets.Project.Code.Runtime.Logic.Fsm;
using Assets.Project.Code.Scripts.Runtime.Utilities;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies.States
{
    public sealed class ChaseState : IState<Enemy>
    {
        private readonly NavMeshAgent agent;
        private readonly EnemyAnimator animator;
        private readonly TargetDetector detector;

        private Transform target;

        public bool TargetReached { get; private set; }

        public Enemy Initializer { get; private set; }

        public ChaseState(Enemy enemy,
                          TargetDetector detector,
                          NavMeshAgent agent,
                          EnemyAnimator animator)
        {
            this.Initializer = enemy;
            this.detector = detector;
            this.agent = agent;
            this.animator = animator;
        }

        public void OnEnter()
        {
            target = detector.Target;
        }

        public void OnExit() =>
            StopFollow();

        public void OnRun()
        {
            TargetReached = IsTargetPositionReached();

            Follow();
        }

        private void Follow()
        {
            agent.destination = target.position;
            agent.transform.LookAt(target);
            animator.Move(agent.speed);
        }

        private void StopFollow()
        {
            animator.StopMove();
        }

        private bool IsTargetPositionReached() =>
            DataExtensions.SqrMagnitudeTo(agent.transform.position, target.position)
                <= agent.stoppingDistance;
    }
}