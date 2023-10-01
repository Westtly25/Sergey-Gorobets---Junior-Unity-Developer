using UnityEngine;
using UnityEngine.AI;
using Assets.Project.Code.Runtime.Logic.Fsm;
using Assets.Project.Code.Scripts.Runtime.Utilities;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies.States
{
    public sealed class AttackState : IState<Enemy>
    {
        private readonly NavMeshAgent agent;
        private readonly AttackBehaviour attackBehaviour;
        private readonly TargetDetector detector;

        private Transform target;

        public bool TargetInAttackZone { get; private set; }
        public Enemy Initializer { get; private set; }

        public AttackState(Enemy enemy,
                           TargetDetector detector,
                           NavMeshAgent agent,
                           AttackBehaviour attackBehaviour)
        {
            this.Initializer = enemy;
            this.detector = detector;
            this.agent = agent;
            this.attackBehaviour = attackBehaviour;
        }

        public void OnEnter()
        {
            target = detector.Target.transform;
        }

        public void OnExit()
        {
        }

        public void OnRun()
        {
            TargetInAttackZone = IsTargetInAttackZone();

            if (TargetInAttackZone)
                attackBehaviour.PerformAttack(target);
            else
                attackBehaviour.InterruptAttack();
        }

        private bool IsTargetInAttackZone() =>
            DataExtensions.SqrMagnitudeTo(agent.transform.position, target.position) <= attackBehaviour.AttackConfig.Range;
    }
}
