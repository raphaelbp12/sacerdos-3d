using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using Scrds.Classes;

public class SkillButtonHandler : MonoBehaviour
{
    private bool listening;
    private string bind = "";
    private Text buttonText;
    private Button btn;

    [SerializeField] public BindingsSlotsEnum slot = BindingsSlotsEnum.firstFlask;

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
    }

    private void OnGUI()
    {
        if (listening)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                BindingsController bindingsController = GameObject.Find("MenuController").GetComponent<BindingsController>();
                string keyStored = bindingsController.bindings.FirstOrDefault(x => x.Value == slot).Key;
                bindingsController.bindings.Remove(keyStored);

                string key = e.keyCode.ToString();
                Debug.Log(key);
                bind = key;
                buttonText.text = key;
                listening = false;
                btn.enabled = true;

                bindingsController.bindings.Add(key, slot);
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
