using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindingsController : MonoBehaviour
{
    // Start is called before the first frame update

    Dictionary<string, Skill> bindings;

    void Start()
    {
        bindings = new Dictionary<string, Skill>();

        bindings.Add("F1", new MeteoroDePegasusSkill());
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            string key = e.keyCode.ToString();
            Debug.Log(key);
            if (bindings.ContainsKey(key))
            {
                bindings[key].DoAction();
            }
        }
    }
}
