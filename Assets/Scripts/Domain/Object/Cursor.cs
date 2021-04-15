using System;
using DataStructure;
using UnityEngine;

namespace Domain.Object
{
    public class Cursor : AbstractMovable
    {
        public Cursor(GameObject gameObject) : base(gameObject)
        {
            _isActive = false;
        }

        private DiscretePositionMap<Cube> _cubePositionMap;

        private bool _isActive;

        private static readonly int ColorPropertyName = Shader.PropertyToID("_Color");

        public void Toggle()
        {
            _isActive = !_isActive;
            ToggleColor();
        }

        private void ToggleColor()
        {
            foreach (Transform child in GameObject.transform)
            {
                // Get the Renderer component from the new cube
                var cubeRenderer = child.gameObject.GetComponent<Renderer>();

                cubeRenderer.material.SetColor(ColorPropertyName, IsActive() ? Color.red : Color.green);
            }
        }

        public bool IsActive()
        {
            return _isActive;
        }

        public void SetCubePositionMap(DiscretePositionMap<Cube> map)
        {
            _cubePositionMap = map;
        }

        private delegate void MoveFunction(IMovable movable);

        // TODO: Is this a little bit too much complicated?
        private void Move(MoveFunction move, MoveFunction reversed, Action moveCursor, Action reverseCursor)
        {
            if (IsActive())
            {
                bool thereIsACubeUnderCursor = _cubePositionMap.Occupied(GetPosition());
                if (thereIsACubeUnderCursor)
                {
                    var cursorPos = GetPosition();
                    Cube cube = _cubePositionMap.Get(cursorPos);

                    move(cube);
                    moveCursor();
                    var nextCursorPos = GetPosition();
                    if (_cubePositionMap.Occupied(nextCursorPos))
                    {
                        reversed(cube);
                        reverseCursor();
                    }
                    else
                    {
                        _cubePositionMap.Relocate(cursorPos, cube.GetPosition());
                    }
                }
                else
                {
                    moveCursor();
                }
            }
            else
            {
                moveCursor();
            }
        }

        public override void MoveLeft()
        {
            Move(cube => cube.MoveLeft(), cube => cube.MoveRight(),
                () => base.MoveLeft(), () => base.MoveRight());
        }

        public override void MoveRight()
        {
            Move(cube => cube.MoveRight(), cube => cube.MoveLeft(), () => base.MoveRight(), () => base.MoveLeft());
        }

        public override void MoveUp()
        {
            Move(cube => cube.MoveUp(), cube => cube.MoveDown(), () => base.MoveUp(), () => base.MoveDown());
        }

        public override void MoveDown()
        {
            Move(cube => cube.MoveDown(), cube => cube.MoveUp(), () => base.MoveDown(), () => base.MoveUp());
        }

        public override void MoveForward()
        {
            Move(cube => cube.MoveForward(), cube => cube.MoveBackward(), () => base.MoveForward(),
                () => base.MoveBackward());
        }

        public override void MoveBackward()
        {
            Move(cube => cube.MoveBackward(), cube => cube.MoveForward(), () => base.MoveBackward(),
                () => base.MoveForward());
        }
    }
}