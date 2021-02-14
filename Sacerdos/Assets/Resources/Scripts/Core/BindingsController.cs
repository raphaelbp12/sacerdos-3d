using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Classes;
using Scrds.Core;
using Scrds.Combat;

public enum FlasksList {
    empty,
    life,
    mana,
    quicksilver
}

public class BindingsController : MonoBehaviour
{
    [SerializeField] public List<FlasksList> flasks = new List<FlasksList>(){FlasksList.empty, FlasksList.empty, FlasksList.empty, FlasksList.empty, FlasksList.empty};
    // Start is called before the first frame update

    public Dictionary<string, BindingsSlotsEnum> bindings;
    private string fileName = "keyBindings";

    private SkillCaller skillCaller;

    public BindingsController()
    {
        this.bindings = SaveFileManagement.LoadFile<Dictionary<string, BindingsSlotsEnum>>(fileName);
    }

    void Update()
    {
        if (skillCaller == null) {
            GameObject playerGameObject = GameObject.FindGameObjectsWithTag("Player")[0];
            this.skillCaller = playerGameObject.GetComponent<SkillCaller>();
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (
            (e.isKey && e.rawType == EventType.KeyDown) ||
            (e.isMouse && e.rawType == EventType.MouseDown)
        ) {
            string key = e.keyCode.ToString();
            if (bindings.ContainsKey(key))
            {
                if (skillCaller == null) {
                    Debug.Log("skillCaller is still null");
                    return;
                }
                Debug.Log(key + " pressed for " + bindings[key].ToString());
                // bindings[key].DoAction();
                switch (bindings[key])
                {
                    case BindingsSlotsEnum.firstSkill:
                        this.skillCaller.Call(0);
                        break;
                    case BindingsSlotsEnum.secondSkill:
                        this.skillCaller.Call(1);
                        break;
                    case BindingsSlotsEnum.thirdSkill:
                        this.skillCaller.Call(2);
                        break;
                    case BindingsSlotsEnum.fourthSkill:
                        this.skillCaller.Call(3);
                        break;
                    case BindingsSlotsEnum.fifthSkill:
                        this.skillCaller.Call(4);
                        break;
                    case BindingsSlotsEnum.sixthSkill:
                        this.skillCaller.Call(5);
                        break;
                    case BindingsSlotsEnum.seventhSkill:
                        this.skillCaller.Call(6);
                        break;
                    case BindingsSlotsEnum.eighthSkill:
                        this.skillCaller.Call(7);
                        break;
                    default:
                        Debug.Log(key + " pressed for " + bindings[key].ToString());
                        break;
                }
            }
        }
    }
}
