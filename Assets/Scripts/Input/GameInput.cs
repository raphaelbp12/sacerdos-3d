// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""dd2bb74f-978f-45e1-8d06-bd47ba03a11c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""427f95dd-28a6-4695-b838-1e469e0906a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Movement"",
                    ""type"": ""Button"",
                    ""id"": ""3a3d48ed-6674-4279-b364-74d40f712b3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Position"",
                    ""type"": ""Value"",
                    ""id"": ""527a95fe-3a31-4e95-a0d5-35ff82435b87"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Menu"",
                    ""type"": ""Button"",
                    ""id"": ""a8e6833d-db6c-4e64-b451-dae0f920d130"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ba5a71cc-4dc0-4c16-84ed-546ab4a6dde8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""60977934-eb5d-4f42-9071-01e5bfbefb9c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""de09eac5-fe75-4962-bc01-d6fcc27670ad"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5c6021ef-17f9-4ff6-800e-7b2383f07e30"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e4876b9-0209-4de6-acbd-ecde6b78f74e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ebc8abc-e8d7-4107-a4aa-9f7b95131a21"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f975806-86b1-4d31-a454-59056a5de9ca"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0bae9d1-861b-4201-b81e-952c92d5b488"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09b44927-c1b8-4e2b-830b-690e4eb84b5e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73cdbe6c-5cc4-4e2a-a3eb-d5cd106ec932"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Skills"",
            ""id"": ""9ad6e265-1a3b-48fb-8059-ce5cf14266a0"",
            ""actions"": [
                {
                    ""name"": ""Skill 1"",
                    ""type"": ""Button"",
                    ""id"": ""66a178f0-fa78-4b53-8c0b-e187b79f7f71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 2"",
                    ""type"": ""Button"",
                    ""id"": ""28c2c41e-b5e0-4d0d-8588-2b723da8094b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 3"",
                    ""type"": ""Button"",
                    ""id"": ""6d56d61c-691e-4cee-8548-7d3db484a2db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 4"",
                    ""type"": ""Button"",
                    ""id"": ""eae3724b-fb97-4897-845d-2a0d8d9360b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3d355a7b-b681-47f5-b5a6-5e2811bb2e63"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b084c5e-7a2a-4a95-a5a1-c92a398b66d7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98a4dfef-a42b-4b29-aa19-bb2ecd27b0b3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5edaa478-69ec-487a-b0a8-dae55ed36a91"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e7055fe-fd67-446d-8354-d56ab315ac6a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c88a4f-f0f5-4354-a257-b326bfa8dcc9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37b104c8-6fff-469b-8803-ff1273266090"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61da7447-2342-459c-9a22-cc2bfc53ccd8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_MouseMovement = m_Gameplay.FindAction("Mouse Movement", throwIfNotFound: true);
        m_Gameplay_MousePosition = m_Gameplay.FindAction("Mouse Position", throwIfNotFound: true);
        m_Gameplay_ToggleMenu = m_Gameplay.FindAction("Toggle Menu", throwIfNotFound: true);
        // Player Skills
        m_PlayerSkills = asset.FindActionMap("Player Skills", throwIfNotFound: true);
        m_PlayerSkills_Skill1 = m_PlayerSkills.FindAction("Skill 1", throwIfNotFound: true);
        m_PlayerSkills_Skill2 = m_PlayerSkills.FindAction("Skill 2", throwIfNotFound: true);
        m_PlayerSkills_Skill3 = m_PlayerSkills.FindAction("Skill 3", throwIfNotFound: true);
        m_PlayerSkills_Skill4 = m_PlayerSkills.FindAction("Skill 4", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_MouseMovement;
    private readonly InputAction m_Gameplay_MousePosition;
    private readonly InputAction m_Gameplay_ToggleMenu;
    public struct GameplayActions
    {
        private @GameInput m_Wrapper;
        public GameplayActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @MouseMovement => m_Wrapper.m_Gameplay_MouseMovement;
        public InputAction @MousePosition => m_Wrapper.m_Gameplay_MousePosition;
        public InputAction @ToggleMenu => m_Wrapper.m_Gameplay_ToggleMenu;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @MouseMovement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseMovement;
                @MousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @ToggleMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleMenu;
                @ToggleMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleMenu;
                @ToggleMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleMenu;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseMovement.started += instance.OnMouseMovement;
                @MouseMovement.performed += instance.OnMouseMovement;
                @MouseMovement.canceled += instance.OnMouseMovement;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @ToggleMenu.started += instance.OnToggleMenu;
                @ToggleMenu.performed += instance.OnToggleMenu;
                @ToggleMenu.canceled += instance.OnToggleMenu;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Player Skills
    private readonly InputActionMap m_PlayerSkills;
    private IPlayerSkillsActions m_PlayerSkillsActionsCallbackInterface;
    private readonly InputAction m_PlayerSkills_Skill1;
    private readonly InputAction m_PlayerSkills_Skill2;
    private readonly InputAction m_PlayerSkills_Skill3;
    private readonly InputAction m_PlayerSkills_Skill4;
    public struct PlayerSkillsActions
    {
        private @GameInput m_Wrapper;
        public PlayerSkillsActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skill1 => m_Wrapper.m_PlayerSkills_Skill1;
        public InputAction @Skill2 => m_Wrapper.m_PlayerSkills_Skill2;
        public InputAction @Skill3 => m_Wrapper.m_PlayerSkills_Skill3;
        public InputAction @Skill4 => m_Wrapper.m_PlayerSkills_Skill4;
        public InputActionMap Get() { return m_Wrapper.m_PlayerSkills; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerSkillsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerSkillsActions instance)
        {
            if (m_Wrapper.m_PlayerSkillsActionsCallbackInterface != null)
            {
                @Skill1.started -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill1;
                @Skill2.started -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill2;
                @Skill2.performed -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill2;
                @Skill2.canceled -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill2;
                @Skill3.started -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill3;
                @Skill3.performed -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill3;
                @Skill3.canceled -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill3;
                @Skill4.started -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill4;
                @Skill4.performed -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill4;
                @Skill4.canceled -= m_Wrapper.m_PlayerSkillsActionsCallbackInterface.OnSkill4;
            }
            m_Wrapper.m_PlayerSkillsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
                @Skill2.started += instance.OnSkill2;
                @Skill2.performed += instance.OnSkill2;
                @Skill2.canceled += instance.OnSkill2;
                @Skill3.started += instance.OnSkill3;
                @Skill3.performed += instance.OnSkill3;
                @Skill3.canceled += instance.OnSkill3;
                @Skill4.started += instance.OnSkill4;
                @Skill4.performed += instance.OnSkill4;
                @Skill4.canceled += instance.OnSkill4;
            }
        }
    }
    public PlayerSkillsActions @PlayerSkills => new PlayerSkillsActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseMovement(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnToggleMenu(InputAction.CallbackContext context);
    }
    public interface IPlayerSkillsActions
    {
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSkill3(InputAction.CallbackContext context);
        void OnSkill4(InputAction.CallbackContext context);
    }
}
