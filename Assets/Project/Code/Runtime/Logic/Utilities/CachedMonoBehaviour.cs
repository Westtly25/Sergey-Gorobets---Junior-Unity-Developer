using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Utilities
{
    public class CachedMonoBehaviour : MonoBehaviour
    {
        private Transform cachedTransform;

        public Transform CachedTransform => cachedTransform;
        public Vector3 CachedPosition => cachedTransform.position;
        public Quaternion CachedRotation => cachedTransform.rotation;


        private void Awake() =>
            cachedTransform = transform;
    }
}
