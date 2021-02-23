using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Combat
{
    public class Flasks: Skill
    {
        string name = "Flask";

        public Flasks() {
            
        }

        public override void DoAction(Vector3 targetWorldPosition)
        {
            Debug.Log(this.name);
        }
    }
}