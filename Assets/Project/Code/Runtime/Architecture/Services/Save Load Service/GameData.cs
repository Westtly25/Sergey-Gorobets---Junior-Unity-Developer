using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service
{
    [Serializable]
    public sealed class GameData
    {
        [SerializeField]
        [Range(byte.MinValue, byte.MaxValue)]
        public int Id;

        [SerializeField, Min(0)]
        public int WinCount = 0;

        [SerializeField, Min(0)]
        public int LoseCount = 0;
    }
}