using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class SkillButtonHandler : MonoBehaviour
{
    private bool listening;
    private string bind = "F1";
    private Text buttonText;
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        buttonText = gameObject.GetComponentInChildren<Text>();

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
                Skill skill = bindingsController.bindings[bind];
                bindingsController.bindings.Remove(bind);

                string key = e.keyCode.ToString();
                Debug.Log(key);
                bind = key;
                buttonText.text = key;
                listening = false;
                btn.enabled = true;

                bindingsController.bindings.Add(key, skill);
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
