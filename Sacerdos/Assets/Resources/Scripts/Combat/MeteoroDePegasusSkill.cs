using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroDePegasusSkill: Skill
{
    string name = "Meteoro de Pegasus";
    bool castingSkill;

    public override void DoAction()
    {
        if (!this.castingSkill)
        {
            this.castingSkill = true;
            Debug.Log(this.name);
        }
    }
}
