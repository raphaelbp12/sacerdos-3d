using UnityEngine;
using Scrds.Movement;
using Scrds.Combat;
using Scrds.Core;

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

        private void Start()
        {
            health = GetComponent<Health>();
            _cursorManager = new CursorManager(cursorMappings);
        }

        void OnEnable()
        {
            _inputReader.StartedMouseMoveEvent += ProcessInteraction;
            _inputReader.MouseMoveEvent += OnMouseMove;
            _inputReader.MouseMoveEvent += UpdateCursor;
            _inputReader.CancelMouseMoveEvent += ClearTarget;
        }

        void OnDisable()
        {
            _inputReader.StartedMouseMoveEvent -= ProcessInteraction;
            _inputReader.MouseMoveEvent -= OnMouseMove;
            _inputReader.MouseMoveEvent -= UpdateCursor;
            _inputReader.CancelMouseMoveEvent -= ClearTarget;
        }

        void Update()
        {
            if (combatTarget) {
                InteractWithCombat(combatTarget);
            }

            if (_lastMovementTarget != null) {
                Move(_lastMovementTarget.Value);
            }
        }

        private void UpdateCursor(Vector2 mousePosition)
        {
            _cursorManager.SetCursor(CursorType.None);

            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
                _cursorManager.SetCursor(CursorType.GUI);
                return;
            }

            if (checkCombatHover(mousePosition) != null) return;
            if (combatTarget) {
                _cursorManager.SetCursor(CursorType.Combat);
                return;
            }

            checkMovementHover(mousePosition);
        }

        private CombatTarget checkCombatHover(Vector2 mousePosition)
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay(mousePosition));
            foreach (RaycastHit hit in hits) {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (target.tag == "Player") continue;

                if (!GetComponent<Fighter>().IsTargetAlive(target.gameObject)) continue;

                _cursorManager.SetCursor(CursorType.Combat);
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

        private RaycastHit? checkMovementHover(Vector2 mousePosition)
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(mousePosition), out hit);

            if (hasHit) {
                _cursorManager.SetCursor(CursorType.Movement);
                return hit;
            }
            return null;
        }

        private void ProcessInteraction(Vector2 mousePosition)
        {
            _interacting = true;

            combatTarget = checkCombatHover(mousePosition);
            if (combatTarget != null) {
                return;
            }

            RaycastHit? movDestination = checkMovementHover(mousePosition);
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

            RaycastHit? movementTarget = checkMovementHover(mousePosition);
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