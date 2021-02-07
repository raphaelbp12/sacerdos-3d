using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Classes;
using Scrds.Core;

public enum SkillsList {
    empty,
    flameDash,
    toxicRain,
    causticArrow
}

public enum FlasksList {
    empty,
    life,
    mana,
    quicksilver
}

public class BindingsController : MonoBehaviour
{
    [SerializeField] public List<SkillsList> skills = new List<SkillsList>(){SkillsList.empty, SkillsList.empty, SkillsList.empty, SkillsList.empty, SkillsList.empty, SkillsList.empty, SkillsList.empty, SkillsList.empty};
    [SerializeField] public List<FlasksList> flasks = new List<FlasksList>(){FlasksList.empty, FlasksList.empty, FlasksList.empty, FlasksList.empty, FlasksList.empty};
    // Start is called before the first frame update

    public Dictionary<string, BindingsSlotsEnum> bindings;
    [SerializeField] public int rotation = 0;
    private string fileName = "keyBindings";

    public BindingsController()
    {
        bindings = SaveFileManagement.LoadFile<Dictionary<string, BindingsSlotsEnum>>(fileName);
    }

    void Start()
    {
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
                Debug.Log(key + " pressed for " + bindings[key].ToString());
                // bindings[key].DoAction();
            }
        }
    }
}
