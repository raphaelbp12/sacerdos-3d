using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Movement;

namespace Scrds.Combat
{
    public class FlameDash: Skill
    {
        public Vector3? mouseProjected;
        private string name = "FlameDash";

        private GameObject playerGameObject;
        private Mover moverController;

        public FlameDash(GameObject player){
            this.playerGameObject = player;
            this.moverController = playerGameObject.GetComponent<Mover>();
        }

        public override void DoAction(Vector3 targetWorldPosition)
        {
            if(this.mouseProjected == null) return;
            Debug.Log(this.name);
            Debug.Log(Input.mousePosition);
            this.moverController.Move((new Vector3(0, 0, 1)) * Time.deltaTime * 10.0f);
        }
    }
}