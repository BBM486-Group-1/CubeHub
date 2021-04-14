using System;
using UnityEngine;
using Cursor = Domain.Object.Cursor;

namespace Behaviour
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private GameObject cursorObject;

        private Cursor _cursor;

        private void Start()
        {
            _cursor = new Cursor(cursorObject);
        }

        public Cursor GetCursor()
        {
            return _cursor;
        }
    }
}