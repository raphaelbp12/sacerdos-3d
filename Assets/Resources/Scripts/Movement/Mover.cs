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
        public float rotationSpeed = 10f;
        public Vector3 rotateTarget;

        private bool isMoving;
        private void Start() {
            rotateTarget = Vector3.forward;
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();

            if (!this.isMoving) {
                this.RotateTowards(rotateTarget);
            }
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
            this.isMoving = true;
            // this.setRotateTarget(destination);
            GetComponent<NavMeshAgent>().speed = (1.0f + movSpeedIncrease) * baseSpeed;
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void setRotateTarget (Vector3 targetPosition) {
            this.rotateTarget = targetPosition;
        }

        private void RotateTowards (Vector3 direction) {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }

        public void Move(Vector3 offset)
        {
            this.isMoving = true;
            GetComponent<NavMeshAgent>().Move(offset);
            navMeshAgent.isStopped = false;
        }

        public void Cancel() {
            this.isMoving = false;
            navMeshAgent.isStopped = true;
        }
    }
}
