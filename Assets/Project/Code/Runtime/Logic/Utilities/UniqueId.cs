using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Utilities
{
    public class UniqueId : MonoBehaviour
    {
        [field: SerializeField]
        public string Id { get; private set; }

        private void Awake() => GenerateId();

        public void GenerateId() =>
          Id = $"{ gameObject.scene.name }_{ Guid.NewGuid().ToString() }";
    }
}