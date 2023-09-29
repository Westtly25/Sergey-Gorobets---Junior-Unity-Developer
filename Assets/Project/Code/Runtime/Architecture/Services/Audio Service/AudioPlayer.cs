using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Architecture.Services.Audio_Service
{
    public class AudioPlayer
    {
        public Sound[] sounds;

        public void Play(string name)
        {
            Sound sound = FindSound(name);

            if (sound == null)
            {
                Debug.LogWarning("Sound with name " + name + " not found.");
                return;
            }

            sound.source.Play();
        }

        public void Stop(string name)
        {
            Sound sound = FindSound(name);

            if (sound == null)
            {
                Debug.LogWarning("Sound with name " + name + " not found.");
                return;
            }

            sound.source.Stop();
        }

        private Sound FindSound(string name) =>
            Array.Find(sounds, sound => sound.name == name);
    }

    [Serializable]
    public class Sound
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