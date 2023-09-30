using System;
using UnityEngine;

namespace Assets.Project.Code.Runtime.Architecture.Services.Audio_Service
{
    public class AudioPlayer
    {
        public SoundItem[] sounds;

        public void Play(string name)
        {
            SoundItem sound = FindSound(name);

            if (sound == null)
            {
                Debug.LogWarning("SoundItem with name " + name + " not found.");
                return;
            }

            sound.source.Play();
        }

        public void Stop(string name)
        {
            SoundItem sound = FindSound(name);

            if (sound == null)
            {
                Debug.LogWarning("SoundItem with name " + name + " not found.");
                return;
            }

            sound.source.Stop();
        }

        private SoundItem FindSound(string name) =>
            Array.Find(sounds, sound => sound.name == name);
    }
}