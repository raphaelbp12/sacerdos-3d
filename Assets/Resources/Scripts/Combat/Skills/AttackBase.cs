using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Movement;

namespace Scrds.Combat
{
    public class AttackBase
    {
        public Vector3? mouseProjected;
        private string name = "AttackBase";

        private GameObject playerGameObject;
        private Mover moverController;
        private StatsController stateController;

        private float nextAttackTime = 0;
        private float fireRate;

        private int numAttacks = 0;

        public AttackBase(GameObject player){
            this.playerGameObject = player;
            this.moverController = playerGameObject.GetComponent<Mover>();
            this.stateController = playerGameObject.GetComponent<StatsController>();
            this.fireRate = 1f / this.stateController.attackSpeed;
        }

        public void DoActionBeforeCallback(Skill callback)
        {
            if (Time.time < this.nextAttackTime) {
                return;
            }
            this.moverController.Cancel();
            Vector3 attackDir = (this.mouseProjected.Value - this.playerGameObject.transform.position).normalized;
            this.moverController.setRotateTarget(attackDir.normalized);
            this.numAttacks += 1;
            this.nextAttackTime = Time.time + this.fireRate;
            Debug.Log(this.name);
            if(this.mouseProjected == null) return;
            callback.DoAction(new Vector3());
        }
    }
}