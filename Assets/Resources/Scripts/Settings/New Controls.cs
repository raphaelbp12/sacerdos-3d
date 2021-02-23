// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Scripts/Settings/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""New action map"",
            ""id"": ""1701f431-5e0d-46c6-bc45-753c898c5925"",
            ""actions"": [
                {
                    ""name"": ""Skill 1"",
                    ""type"": ""Button"",
                    ""id"": ""4719cf86-7cbf-4acd-8c84-96ca9bc55918"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold,Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7f6a532-3e96-45ee-a8ef-8d4cf7ba517f"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Skill1 = m_Newactionmap.FindAction("Skill 1", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Skill1;
    public struct NewactionmapActions
    {
        private @NewControls m_Wrapper;
        public NewactionmapActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skill1 => m_Wrapper.m_Newactionmap_Skill1;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @Skill1.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSkill1;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface INewactionmapActions
    {
        void OnSkill1(InputAction.CallbackContext context);
    }
}
