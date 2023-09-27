using UnityEngine;

namespace Assets.Project.Code.Scripts.Runtime.Utilities
{
    [RequireComponent(typeof(MeshRenderer))]
    public class GpuInstancing : MonoBehaviour
    {
        private void Awake()
        {
            MaterialPropertyBlock materialPropertyBlock = new ();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}