using UnityEngine;
using Cysharp.Threading.Tasks;
using Assets.Project.Code.Runtime.Logic.Characters.Heroes;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    [RequireComponent(typeof(SphereCollider))]
    public class TargetDetector : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private SphereCollider sphereCollider;

        public Transform Target;

        private void Awake() =>
            sphereCollider = GetComponent<SphereCollider>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Hero>(out Hero hero))
            {
                Target = hero.transform;
#if UNITY_EDITOR
                Debug.Log($"{this.name} found target : Hero - {hero.name}");
#endif
            }
        }

        private void OnTriggerExit(Collider other) =>
            Target = null;
    }
}