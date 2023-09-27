using System;
using Zenject;
using UnityEngine;
using Assets.Project.Code.Scripts.Runtime.Architecture.Pause_system;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;

namespace Assets.Project.Code.Runtime.Logic.Camera_Logic
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 offset;

        [SerializeField, Range(0.1f, 10f)]
        private float rotateSpeed = 3f;

        [SerializeField, Range(0, -180)]
        private float minVertAngle = -20;

        [SerializeField, Range(0, 180)]
        private float maxVertAngle = 45;

        [SerializeField]
        private Camera mainCamera;

        private float rotationX;
        private float rotationY;

        [SerializeField]
        private Transform target;

        private IPauseHandler pauseHandler;
        private Hero hero;

        [Inject]
        public void Constructor(IPauseHandler pauseHandler, Hero hero)
        {
            this.pauseHandler = pauseHandler;
            this.hero = hero;
        }

        public Quaternion PlanarRotation =>
            Quaternion.Euler(0, rotationY, 0);

        private void Awake() =>
            mainCamera = GetComponent<Camera>();

        private void Start()
        {
            target = hero.transform;
        }

        private void Update()
        {
            if (!pauseHandler.IsPaused)
                Rotate();
        }

        private void Rotate()
        {
            rotationX += Input.GetAxis("Mouse Y") * -1 * rotateSpeed;
            rotationX = Mathf.Clamp(rotationX, minVertAngle, maxVertAngle);
            rotationY += Input.GetAxis("Mouse X") * rotateSpeed;

            Quaternion rotateTo = Quaternion.Euler(rotationX, rotationY, 0);
            Vector3 moveTo = target.position - rotateTo * offset;

            transform.position = moveTo;
            transform.rotation = rotateTo;
        }
    }
}