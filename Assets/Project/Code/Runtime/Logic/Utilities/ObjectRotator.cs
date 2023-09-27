using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Utilities
{
    public sealed class ObjectRotator : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)]
        private float rotationSpeed;

        private void Update()
        {
            float speed = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, speed, Space.Self);
        }
    }
}