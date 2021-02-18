using System;
using System.Collections;
using System.Collections.Generic;
using Scrds.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Scrds.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        Health health;

        float baseSpeed = 5.0f;
        private void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        public void StartMoveAction(Vector3 destination) {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination, float movSpeedIncrease = 0f)
        {
            GetComponent<NavMeshAgent>().speed = (1.0f + movSpeedIncrease) * baseSpeed;
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Move(Vector3 offset)
        {
            GetComponent<NavMeshAgent>().Move(offset);
            navMeshAgent.isStopped = false;
        }

        public void Cancel() {
            navMeshAgent.isStopped = true;
        }
    }
}
