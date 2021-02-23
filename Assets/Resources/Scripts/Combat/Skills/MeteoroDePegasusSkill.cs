using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Combat
{
    public class MeteoroDePegasusSkill: Skill
    {
        string name = "Meteoro de Pegasus";

        public override void DoAction(Vector3 targetWorldPosition)
        {
            Debug.Log(this.name);
        }
    }
}