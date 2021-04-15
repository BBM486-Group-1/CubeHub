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

                // Call SetColor using the shader property name "_Color" and setting the color to red
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

        private void MoveCubeUnderCursor(MoveFunction moveFunction)
        { 
            if (IsActive())
            {
                if (_cubePositionMap.Occupied(GetPosition()))
                {
                    Cube cube = _cubePositionMap.Get(GetPosition());
                    moveFunction(cube);
                    _cubePositionMap.Relocate(GetPosition(), cube.GetPosition());
                }
            }
        }
        
        public override void MoveLeft()
        {
            MoveCubeUnderCursor(cube => cube.MoveLeft());
            base.MoveLeft();
        }

        public override void MoveRight()
        {
            MoveCubeUnderCursor(cube => cube.MoveRight());
            base.MoveRight();
        }

        public override void MoveUp()
        {
            MoveCubeUnderCursor(cube => cube.MoveUp());
            base.MoveUp();
        }

        public override void MoveDown()
        {
            MoveCubeUnderCursor(cube => cube.MoveDown());
            base.MoveDown();
        }

        public override void MoveForward()
        {
            MoveCubeUnderCursor(cube => cube.MoveForward());
            base.MoveForward();
        }

        public override void MoveBackward()
        {
            MoveCubeUnderCursor(cube => cube.MoveBackward());
            base.MoveBackward();
        }
    }
}