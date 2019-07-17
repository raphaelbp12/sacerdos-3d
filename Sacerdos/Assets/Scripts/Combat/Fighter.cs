using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Combat
{
    public class Fighter : MonoBehaviour
    {
        // Start is called before the first frame update
        public void Attack(CombatTarget target)
        {
            print("bla" + target.name);
        }
    }
}
