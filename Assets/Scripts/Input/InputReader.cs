using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Input reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{
    // Gameplay 
    public event Action<Vector2> MoveEvent = delegate { };
    public event Action<Vector2> MouseMoveEvent = delegate { };
    public event Action<Vector2> StartedMouseMoveEvent = delegate { };
    public event Action CancelMouseMoveEvent = delegate { };
    public event Action<int> UseSkillEvent = delegate { };
    public event Action<int> CancelSkillEvent = delegate { };
    public event Action ToggleMenuEvent = delegate { };

    private GameInput _gameInput;

    void OnEnable()
    {
        if (_gameInput == null) {
            _gameInput = new GameInput();
            _gameInput.Gameplay.SetCallbacks(this);
            SetSkillCallbacks(_gameInput.PlayerSkills.Get());
        }

        _gameInput.Enable();
    }

    void OnDisable()
    {
        _gameInput.Disable();
    }

    void SetSkillCallbacks(InputActionMap skillsActionMap)
    {
        foreach ((int skillId, InputAction action) in skillsActionMap.Select((v, i) => (i, v))) {
            void handler(InputAction.CallbackContext ctx) { OnSkill(skillId, ctx); }
            action.performed += handler;
            action.canceled += handler;
            action.started += handler;
        }
    }

    void OnSkill(int i, InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            UseSkillEvent.Invoke(i);
        }

        if (context.phase == InputActionPhase.Canceled) {
            CancelSkillEvent.Invoke(i);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        bool performed = context.phase == InputActionPhase.Performed;
        bool canceled = context.phase == InputActionPhase.Canceled;
        bool isOverUI = EventSystem.current.IsPointerOverGameObject();

        if (performed && !isOverUI) {
            StartedMouseMoveEvent.Invoke(Mouse.current.position.ReadValue());
        } else if (canceled) {
            CancelMouseMoveEvent.Invoke();
        }
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        MouseMoveEvent.Invoke(mousePosition);
    }

    public void OnToggleMenu(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
