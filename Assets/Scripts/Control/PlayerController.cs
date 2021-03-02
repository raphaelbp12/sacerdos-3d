using UnityEngine;
using Scrds.Movement;
using Scrds.Combat;
using Scrds.Core;
using UnityEngine.InputSystem;

namespace Scrds.Control
{
    public class PlayerController : MonoBehaviour
    {
        private CombatTarget combatTarget;

        [SerializeField] CursorMapping[] cursorMappings = null;
        CursorManager _cursorManager;

        [SerializeField] InputReader _inputReader = default;
        private Vector3? _lastMovementTarget = null;

        private bool _interacting = false;

        Health health;

        private Vector2 _lastMousePosition;

        private void Start()
        {
            health = GetComponent<Health>();
            _cursorManager = new CursorManager(cursorMappings);
        }

        void OnEnable()
        {
            _inputReader.MouseInteractionEvent += ProcessInteraction;
            _inputReader.MouseMoveEvent += OnMousePosition;
            _inputReader.CancelMouseInteractionEvent += ClearTarget;
        }

        void OnDisable()
        {
            _inputReader.MouseInteractionEvent -= ProcessInteraction;
            _inputReader.MouseMoveEvent -= OnMousePosition;
            _inputReader.CancelMouseInteractionEvent -= ClearTarget;
        }

        void Update()
        {
            UpdateCursor(_lastMousePosition);
            OnMouseMove(_lastMousePosition);

            if (combatTarget) {
                InteractWithCombat(combatTarget);
            }

            if (_lastMovementTarget != null) {
                Move(_lastMovementTarget.Value);
            }
        }

        private void OnMousePosition(Vector2 position)
        {
            _lastMousePosition = position;
        }

        private void UpdateCursor(Vector2 mousePosition)
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
                _cursorManager.SetCursor(CursorType.GUI);
                return;
            }

            if (combatTarget || CheckCombatHover(mousePosition) != null) {
                _cursorManager.SetCursor(CursorType.Combat);
                return;
            }

            if (CheckMovementHover(mousePosition) != null) {
                _cursorManager.SetCursor(CursorType.Movement);
                return;
            }

            _cursorManager.SetDefaultCursor();
        }

        private CombatTarget CheckCombatHover(Vector2 mousePosition)
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay(mousePosition));
            foreach (RaycastHit hit in hits) {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (target.CompareTag("Player")) continue;

                if (!GetComponent<Fighter>().IsTargetAlive(target.gameObject)) continue;

                return target;
            }
            return null;
        }

        private void InteractWithCombat(CombatTarget target)
        {
            Health targetHealth = target.gameObject.GetComponent<Health>();
            if (targetHealth.IsDead()) {
                return;
            }
            GetComponent<Fighter>().Attack(target.gameObject);
        }

        private RaycastHit? CheckMovementHover(Vector2 mousePosition)
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(mousePosition), out hit);

            if (hasHit) {
                return hit;
            }
            return null;
        }

        private void ProcessInteraction(Vector2 mousePosition)
        {
            _interacting = true;

            combatTarget = CheckCombatHover(mousePosition);
            if (combatTarget != null) {
                return;
            }

            RaycastHit? movDestination = CheckMovementHover(mousePosition);
            if (movDestination != null) {
                _lastMovementTarget = movDestination.Value.point;
            } else {
                _lastMovementTarget = null;
            }
        }

        private void OnMouseMove(Vector2 mousePosition)
        {
            if (combatTarget)
                return;

            if (!_interacting)
                return;

            RaycastHit? movementTarget = CheckMovementHover(mousePosition);
            if (movementTarget != null) {
                _lastMovementTarget = movementTarget.Value.point;
            }
        }

        private void ClearTarget()
        {
            _interacting = false;
            combatTarget = null;
            _lastMovementTarget = null;
        }

        private void Move(Vector3 point)
        {
            GetComponent<Mover>().StartMoveAction(point);
        }

        private static Ray GetMouseRay(Vector2 mousePosition)
        {
            return Camera.main.ScreenPointToRay(mousePosition);
        }
    }
}