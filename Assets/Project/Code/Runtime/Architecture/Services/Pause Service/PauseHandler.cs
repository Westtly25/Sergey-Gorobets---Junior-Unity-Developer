﻿using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Assets.Project.Code.Scripts.Runtime.Architecture.Pause_system
{
    public sealed class PauseHandler : IPauseHandler
    {
        private readonly List<IPauseListener> listeners = new(10);
        private bool isPaused;
        private readonly DiContainer diContainer;

        public bool IsPaused
        {
            get => isPaused;
            private set => isPaused = value;
        }

        [Inject]
        public PauseHandler(DiContainer diContainer) =>
            this.diContainer = diContainer;

        #region Advanced Pause
        public async UniTask Initialize()
        {
            List<IPauseListener> dependencies = diContainer.ResolveAll<IPauseListener>();

            for (int i = 0; i < dependencies.Count; i++)
                Register(dependencies[i]);

            await UniTask.CompletedTask;
        }
        public void Register(IPauseListener listener) =>
            listeners.Add(listener);
        public void UnRegister(IPauseListener listener) =>
            listeners.Remove(listener);
        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;

            if (listeners == null)
                return;

            for (int i = 0; i < listeners.Count; i++)
                listeners[i].Pause(isPaused);
        }
        #endregion

        public void SetPauseSimpleWay(bool isPaused)
        {
            IsPaused = isPaused;

            if (isPaused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}