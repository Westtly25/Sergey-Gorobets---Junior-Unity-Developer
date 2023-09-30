﻿using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Architecture.Services.Audio_Service
{
    [Serializable]
    public class SoundItem
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 1f;
        [Range(0.1f, 3f)]
        public float pitch = 1f;
        public bool loop;
        [HideInInspector]
        public AudioSource source;
    }
}