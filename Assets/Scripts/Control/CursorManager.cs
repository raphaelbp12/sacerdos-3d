using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Control
{
    public enum CursorType
    {
        None,
        Movement,
        Combat,
        GUI
    }

    [System.Serializable]
    public struct CursorMapping
    {
        public CursorType type;
        public Texture2D texture;
        public Vector2 hotspot;
    }

    public class CursorManager
    {
        IDictionary<CursorType, CursorMapping> _cursors = new Dictionary<CursorType, CursorMapping>();
        CursorMapping _default;
        CursorType _currentCursorType;

        public CursorManager(IList<CursorMapping> cursors)
        {
            foreach (CursorMapping cursor in cursors) {
                _cursors.Add(cursor.type, cursor);
            }

            if (_cursors.TryGetValue(CursorType.None, out CursorMapping noneCursor)) {
                _default = noneCursor;
            } else {
                _default = new CursorMapping();
            }

            SetCursor(CursorType.None);
        }

        public void SetDefaultCursor()
        {
            SetCursor(CursorType.None);
        }

        public void SetCursor(CursorType type)
        {
            if (_currentCursorType == type)
                return;

            _currentCursorType = type;

            if (_cursors.TryGetValue(type, out CursorMapping cursor)) {
                Cursor.SetCursor(cursor.texture, cursor.hotspot, CursorMode.Auto);
            } else {
                Cursor.SetCursor(_default.texture, _default.hotspot, CursorMode.Auto);
            }
        }
    }
}