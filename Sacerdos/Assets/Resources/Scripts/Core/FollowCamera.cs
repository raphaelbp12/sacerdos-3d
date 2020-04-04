using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;

        [SerializeField] float heightOffset = 7;
        [SerializeField] float zOffset = 4;
        private Camera mainCamera;

        private void Start() {
            mainCamera = Camera.main;
            mainCamera.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
        
        void LateUpdate()
        {
            mainCamera.transform.position = target.position + new Vector3(0, heightOffset, -zOffset);
            transform.position = target.position;
        }
    }
}
