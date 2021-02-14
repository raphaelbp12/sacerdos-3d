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

        public override void DoAction()
        {
            Debug.Log(this.name);
        }
    }
}