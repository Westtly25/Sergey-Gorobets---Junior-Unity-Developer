using UnityEngine;
using UnityEngine.AI;
using Assets.Project.Code.Runtime.Logic.Fsm;
using Assets.Project.Code.Runtime.Logic.Shooting;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies.States;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [RequireComponent (typeof(Rigidbody))]
    [RequireComponent (typeof(NavMeshAgent))]
    [RequireComponent (typeof(EnemyAnimator))]
    [RequireComponent (typeof(AttackBehaviour))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [Header("Data")]
        [SerializeField]
        private EnemyConfig enemyConfig;
        [SerializeField]
        private Health health;

        [Header("Require Components")]
        [SerializeField]
        private EnemyAnimator animator;
        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField]
        private Rigidbody rigBody;
        [SerializeField]
        private TargetDetector detector;
        [SerializeField]
        private AttackBehaviour attackBehaviour;

        [Header("Fsm & States")]
        private AwaitState awaitState;
        private ChaseState chaseState;
        private AttackState attackState;
        private DeathState deathState;
        private StateMachine<Enemy> enemyFsm;

        public Health Health => health;

        private void Awake()
        {
            Initialize();
            InitializeFsm();
        }

        private void Start() =>
            enemyFsm.SetState<AwaitState>();

        private void Update() =>
            enemyFsm.Run();

        public void Initialize()
        {
            health.SetData(enemyConfig.Health, enemyConfig.Health);
            animator = GetComponent<EnemyAnimator>();
            agent = GetComponent<NavMeshAgent>();
            rigBody = GetComponent<Rigidbody>();
            detector = GetComponentInChildren<TargetDetector>();
            attackBehaviour = GetComponent<AttackBehaviour>();
            detector.Initialized(enemyConfig.AggroZoneSize);
        }

        private void InitializeFsm()
        {
            awaitState = new (this, animator);
            chaseState = new (this, detector, agent, animator);
            attackState = new (this, detector, agent, attackBehaviour);
            deathState = new (this, animator, agent);

            enemyFsm = new StateMachine<Enemy>(awaitState, chaseState, attackState, deathState);

            BindTransitions();
            BindAnyTransitions();
        }
        private void BindTransitions()
        {
            enemyFsm.AddTransition<AwaitState, ChaseState>(condition: () => detector.Target != null);
            enemyFsm.AddTransition<ChaseState, AwaitState>(condition: () => detector.Target == null);
            enemyFsm.AddTransition<ChaseState, AttackState>(condition: () => chaseState.TargetReached);
            enemyFsm.AddTransition<AttackState, ChaseState>(condition: () => !attackState.TargetInAttackZone);
        }
        private void BindAnyTransitions() =>
            enemyFsm.AddAnyTransition<DeathState>(condition: () => health.IsDead == true);

        public void ApplyDamage(float damage) =>
            health.AddDamage(damage);
    }
}