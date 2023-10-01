using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Camera_Logic;
using Assets.Project.Code.Runtime.Logic.Characters.Enemies;

namespace Assets.Project.Code.Runtime.Logic.Characters.Heroes
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private CameraController cameraController;
        [SerializeField]
        private HeroAnimator heroAnimator;

        private HeroConfig heroConfig;

        private Quaternion targetRotation;

        private void Awake() =>
            InitializeComponents();

        private void Update() =>
            Move();

        public void Initialize(HeroConfig heroConfig) =>
            this.heroConfig = heroConfig;

        public void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 input = (new Vector3(horizontalInput, 0, verticalInput)).normalized;
            Vector3 direction = cameraController.PlanarRotation * input;

            float speedToMove = 0;

            if (direction.magnitude > 0.01)
            {
                speedToMove = heroConfig.WalkSpeed * Time.deltaTime;

                if (Input.GetKey(KeyCode.LeftShift))
                    speedToMove = heroConfig.RunSpeed * Time.deltaTime;

                characterController.Move(direction * speedToMove);
                targetRotation = Quaternion.LookRotation(direction);
                heroAnimator.Move(characterController.velocity.magnitude);
            }
            else heroAnimator.StopMove();

            RotateToCameraDirection();
        }

        private void RotateToCameraDirection() =>
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, heroConfig.RotateSpeed * Time.deltaTime);

        private void InitializeComponents()
        {
            heroAnimator = GetComponent<HeroAnimator>();
            characterController = GetComponent<CharacterController>();
            cameraController = Camera.main.GetComponent<CameraController>();
        }
    }
}