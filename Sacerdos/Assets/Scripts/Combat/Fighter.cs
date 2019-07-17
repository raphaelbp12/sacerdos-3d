using System.Collections;
using System.Collections.Generic;
using Scrds.Movement;
using UnityEngine;

namespace Scrds.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        public float distance;
        Transform target;
        private void Update()
        {
            if (target == null) return;

            if (target != null && !IsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            } else {
                GetComponent<Mover>().Stop();
            }
        }

        private bool IsInRange()
        {
            distance = Vector3.Distance(target.position, transform.position);
            return distance < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("bla" + target.name);
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
