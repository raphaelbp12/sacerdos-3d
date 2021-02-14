using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Movement;

namespace Scrds.Combat
{
    public class Walk: Skill
    {
        private string name = "Walk";

        private GameObject playerGameObject;
        private Mover moverController;

        public Walk(GameObject player){
            this.playerGameObject = player;
            this.moverController = playerGameObject.GetComponent<Mover>();
        }

        public override void DoAction()
        {
            Debug.Log(this.name);
            this.moverController.MoveTo(new Vector3(0, 0, 0));
        }
    }
}