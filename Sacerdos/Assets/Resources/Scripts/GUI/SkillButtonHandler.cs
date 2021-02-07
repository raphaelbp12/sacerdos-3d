using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scrds.Classes;
using Scrds.Core;

public class SkillButtonHandler : MonoBehaviour
{
    private bool listening;
    private string bind = "";
    private Text buttonText;
    private Button btn;

    [SerializeField] public BindingsSlotsEnum slot = BindingsSlotsEnum.firstFlask;

    private string fileName = "keyBindings";

    public Dictionary<string, BindingsSlotsEnum> savedBindings;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        buttonText = gameObject.GetComponentInChildren<Text>();

        BindingsController bindingsController = GameObject.Find("MenuController").GetComponent<BindingsController>();
        if (bindingsController != null && bindingsController.bindings != null && bindingsController.bindings.Count > 0) {
            bind = bindingsController.bindings.FirstOrDefault(x => x.Value == slot).Key;
        }

        buttonText.text = bind;

        // savedBindings = SaveFileManagement.LoadFile<Dictionary<string, BindingsSlotsEnum>>(fileName);
    }

    private void OnGUI()
    {
        if (listening)
        {
            Event e = Event.current;
            if (e.isKey && e.rawType == EventType.KeyDown)
            {
                BindingsController bindingsController = GameObject.Find("MenuController").GetComponent<BindingsController>();
                string keyStored = bindingsController.bindings.FirstOrDefault(x => x.Value == slot).Key;

                if (keyStored != null)
                {
                    bindingsController.bindings.Remove(keyStored);
                }                

                string key = e.keyCode.ToString();

                if (bindingsController.bindings.Any(x => x.Key == key))
                {
                    Debug.Log("key already exists");
                    return;
                }
                Debug.Log(key);
                bind = key;
                buttonText.text = key;
                listening = false;
                btn.enabled = true;

                bindingsController.bindings.Add(key, slot);

                SaveFileManagement.SaveFile<Dictionary<string, BindingsSlotsEnum>>(bindingsController.bindings, fileName);
            }
        }
    }

    void OnClick()
    {
        buttonText.text = "Press a button";
        listening = true;
        btn.enabled = false;
    }
}
