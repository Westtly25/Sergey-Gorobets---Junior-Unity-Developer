using UnityEngine;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [RequireComponent(typeof(SphereCollider))]
    public class TargetDetector : MonoBehaviour
    {
        [SerializeField]
        private SphereCollider sphereCollider;

        public Transform Target;

        public void Initialized(float dectedRange) =>
            sphereCollider.radius = dectedRange;

        private void Awake() =>
            sphereCollider = GetComponent<SphereCollider>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Hero>(out Hero hero))
                Target = hero.transform;
        }

        private void OnTriggerExit(Collider other) =>
            Target = null;
    }
}