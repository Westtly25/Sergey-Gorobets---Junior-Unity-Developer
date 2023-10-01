using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Project.Code.Runtime.Logic.Level
{
    public class Pool<T> where T : MonoBehaviour
    {
        private T toPool;
        private IObjectPool<T> pool;

        public Pool() { }

        public Pool(T toPool)
        {
            this.toPool = toPool;
            CreatePool();
        }

        public void Initialize(T toPool)
        {
            this.toPool = toPool;
            CreatePool();
        }

        private void CreatePool() =>
            pool = new ObjectPool<T>(OnCreate, OnGet, OnRelease, OnDestroy, true, 10, 10);

        private T OnCreate()
        {
            throw new NotImplementedException();
        }

        private void OnGet(T poolable)
        {
            poolable.gameObject.SetActive(true);
        }

        private void OnRelease(T poolable)
        {
            poolable.gameObject.SetActive(false);
        }

        private void OnDestroy(T poolable)
        {
            throw new NotImplementedException();
        }

        public virtual void Clean()
        {
            if (pool != null)
                pool.Clear();
        }
    }
}