using System.Collections;
using System.Collections.Generic;
using Scrds.Core;
using Scrds.Movement;
using UnityEngine;

namespace Scrds.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float accuracyRating = 0f;
        [SerializeField] float evasionRating = 0f;
        [SerializeField] float blockRating = 0f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;
        Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target.IsDead()) return;

            if (target != null && !IsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            } else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggetAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggetAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        private bool IsInRange()
        {
            return Vector3.Distance(target.transform.position, transform.position) < weaponRange;
        }

        public bool IsTargetAlive(GameObject combatTarget){
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
            // print("bla" + target.name);
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        void Hit() {
            if (target == null) return;
            target.TakeDamage(weaponDamage);
            DamagePopup.Create(target.healthBarPosition, Mathf.FloorToInt(weaponDamage), false);
            StopAttack();
            target = null;
        }
    }
}
