using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Movement;
using Scrds.Combat;
using Scrds.Core;

namespace Scrds.Control
{
    public class PlayerController : MonoBehaviour
    {
        enum CursorType
        {
            None,
            Movement,
            Combat,
            GUI
        }

        [System.Serializable]
        struct CursorMapping
        {
            public CursorType type;
            public Texture2D texture;
            public Vector2 hotspot;
        }

        private bool mousePressedWhileAttacking = false;
        private CombatTarget combatTarget;

        [SerializeField] CursorMapping[] cursorMappings = null;

        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
        }

        void Update()
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
                SetCursor(CursorType.GUI);
                return;
            }

            if (health.IsDead()) {
                SetCursor(CursorType.None);
                return;
            }

            bool isMouse0Pressed = Input.GetMouseButton(0);

            if (!isMouse0Pressed) {
                mousePressedWhileAttacking = false;
            }

            if (isMouse0Pressed && mousePressedWhileAttacking) {
                InteractWithCombat(combatTarget);
                return;
            }
            combatTarget = checkCombatHover();
            if (combatTarget != null) {
                if (isMouse0Pressed) InteractWithCombat(combatTarget);
                return;
            }

            RaycastHit? movDestination = checkMovementHover();
            if (movDestination != null) {
                if (isMouse0Pressed) InteractWithMovement(movDestination);
                return;
            }

            SetCursor(CursorType.None);
        }

        private CombatTarget checkCombatHover()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits) {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (target.tag == "Player") continue;

                if (!GetComponent<Fighter>().IsTargetAlive(target.gameObject)) continue;

                SetCursor(CursorType.Combat);
                return target;
            }
            return null;
        }

        private void InteractWithCombat(CombatTarget target)
        {
            Health targetHealth = target.gameObject.GetComponent<Health>();
            if (targetHealth.IsDead()) {
                mousePressedWhileAttacking = false;
                return;
            }
            mousePressedWhileAttacking = true;
            GetComponent<Fighter>().Attack(target.gameObject);
        }

        private RaycastHit? checkMovementHover()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit) {
                SetCursor(CursorType.Movement);
                return hit;
            }
            return null;
        }

        private void InteractWithMovement(RaycastHit? hit)
        {
            if (hit != null) {
                GetComponent<Mover>().StartMoveAction(hit.Value.point);
            }
        }

        private void SetCursor(CursorType type)
        {
            CursorMapping mapping = GetCursorMapping(type);
            Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
        }

        private CursorMapping GetCursorMapping(CursorType type)
        {
            foreach (CursorMapping mapping in cursorMappings) {
                if (mapping.type == type) {
                    return mapping;
                }
            }
            return cursorMappings[0];
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}