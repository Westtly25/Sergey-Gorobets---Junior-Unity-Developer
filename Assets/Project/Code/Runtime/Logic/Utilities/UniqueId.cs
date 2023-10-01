using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Utilities
{
    public class UniqueId : MonoBehaviour
    {
        public string Id { get; private set; }

        public void GenerateId() =>
          Id = $"{gameObject.scene.name}_{Guid.NewGuid().ToString()}";
    }
}