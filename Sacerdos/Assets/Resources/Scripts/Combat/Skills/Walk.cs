using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Movement;

namespace Scrds.Combat
{
    public class Walk: Skill
    {
        public Vector3? mouseProjected;
        private string name = "Walk";

        private GameObject playerGameObject;
        private Mover moverController;

        public Walk(GameObject player){
            this.playerGameObject = player;
            this.moverController = playerGameObject.GetComponent<Mover>();
        }

        public override void DoAction()
        {
            if(this.mouseProjected == null) return;
            Debug.Log(this.name);
            Debug.Log(Input.mousePosition);
            this.moverController.MoveTo(this.mouseProjected.Value, 0.0f);
        }
    }
}