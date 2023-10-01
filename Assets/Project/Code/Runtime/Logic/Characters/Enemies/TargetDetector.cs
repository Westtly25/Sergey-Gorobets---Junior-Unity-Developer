using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [RequireComponent(typeof(SphereCollider))]
    public sealed class TargetDetector : MonoBehaviour
    {
        [SerializeField]
        private SphereCollider sphereCollider;

        public Hero Target { get; private set; }

        public void Initialized(float dectedRange) =>
            sphereCollider.radius = dectedRange;

        private void Awake() =>
            sphereCollider = GetComponent<SphereCollider>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Hero>(out Hero detected))
                Target = detected;
        }

        private void OnTriggerExit(Collider other) =>
            Target = null;
    }
}