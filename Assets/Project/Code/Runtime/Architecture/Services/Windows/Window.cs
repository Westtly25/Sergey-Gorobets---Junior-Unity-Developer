﻿using Zenject;
using UnityEngine;

namespace Assets.Code.Runtime.Services.Windows
{
    public abstract class Window : MonoBehaviour
    {
        protected DiContainer diContainer;

        [Inject]
        public void Constructor(DiContainer diContainer) =>
            this.diContainer = diContainer;

        public virtual void Initialize() { }

        public virtual void Show()
        {
            this.gameObject.SetActive(true);
            Subscribe();
        }

        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
            UnSubscribe();
        }

        public virtual void Subscribe() { }
        public virtual void UnSubscribe() { }
    }
}