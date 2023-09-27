﻿using UnityEngine;
using System.Linq;
using System.Collections;
using Assets.Project.Code.Runtime.Logic.Shooting;

namespace Assets.Project.Code.Runtime.Logic.Characters.Enemies
{
    public class AttackBehaviour : MonoBehaviour
    {
        private const float OffsetY = 0.5f;
        private bool isAttacking = false;

        [SerializeField]
        protected AttackConfig attackConfig;

        protected Collider[] hits = new Collider[1];
        protected IEnumerator routine;

        public void Initialize(AttackConfig attackConfig) =>
            this.attackConfig = attackConfig;

        public virtual void PerformAttack(Transform target)
        {
            if (target == null && attackConfig == null)
                return;

            if (isAttacking)
                return;

            routine = StartAttack(target);
            StartCoroutine(routine);
        }

        public virtual void InterruptAttack()
        {
            if (routine == null)
                return;

            StopCoroutine(routine);
            routine = null;
            isAttacking = false;
        }

        private IEnumerator StartAttack(Transform target)
        {
            isAttacking = true;

            while (isAttacking)
            {
                transform.LookAt(target);

                if (Hit(out Collider hit))
                {
                    if (hit.TryGetComponent<IDamageable>(out IDamageable damageable))
                            damageable.ApplyDamage(attackConfig.Damage);
                }

                yield return new WaitForSeconds(attackConfig.Cooldown);
            }

            isAttacking = false;
            InterruptAttack();
        }

        private bool Hit(out Collider hit)
        {
            int hitAmount = Physics.OverlapSphereNonAlloc(CalculatedOffset(),
                            attackConfig.Range, hits, attackConfig.LayerMask);

            hit = hits.FirstOrDefault();

            return hitAmount > 0;
        }

        private Vector3 CalculatedOffset()
        {
            return new Vector3(transform.position.x, transform.position.y + OffsetY, transform.position.z)
                + transform.forward * attackConfig.Range;
        }
    }
}