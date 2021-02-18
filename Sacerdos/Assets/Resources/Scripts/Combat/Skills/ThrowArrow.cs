﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Movement;

namespace Scrds.Combat
{
    public class ThrowArrow: Skill
    {
        public Transform pfArrow;
        public Vector3? mouseProjected;
        private string name = "ThrowArrow";

        private GameObject playerGameObject;

        private Transform projectileSpawn;
        private Mover moverController;

        public ThrowArrow(GameObject player){
            this.playerGameObject = player;
            this.moverController = playerGameObject.GetComponent<Mover>();
            this.projectileSpawn = playerGameObject.GetComponent<Fighter>().projectileSpawn;
        }

        public override void DoAction()
        {
            if(this.mouseProjected == null) return;
            Transform arrowTransform = Object.Instantiate(this.pfArrow, this.projectileSpawn.position, Quaternion.identity);
            Vector3 shootDir = (this.mouseProjected.Value - this.playerGameObject.transform.position).normalized;
            arrowTransform.GetComponent<ArrowScript>().Setup(shootDir);
            Debug.Log(this.name);
            Debug.Log(Input.mousePosition);
        }
    }
}