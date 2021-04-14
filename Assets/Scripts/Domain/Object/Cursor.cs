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

        private delegate void MoveCube(Cube cube);

        private void MoveCubeUnderIfOccupied(MoveCube moveCube)
        { 
            if (IsActive())
            {
                if (_cubePositionMap.Occupied(GetPosition()))
                {
                    Cube cube = _cubePositionMap.Get(GetPosition());
                    moveCube(cube);
                    _cubePositionMap.Relocate(GetPosition(), cube.GetPosition());
                }
            }
        }
        
        public override void MoveLeft()
        {
            MoveCubeUnderIfOccupied(cube => cube.MoveLeft());
            base.MoveLeft();
        }

        public override void MoveRight()
        {
            MoveCubeUnderIfOccupied(cube => cube.MoveRight());
            base.MoveRight();
        }

        public override void MoveUp()
        {
            MoveCubeUnderIfOccupied(cube => cube.MoveUp());
            base.MoveUp();
        }

        public override void MoveDown()
        {
            MoveCubeUnderIfOccupied(cube => cube.MoveDown());
            base.MoveDown();
        }

        public override void MoveForward()
        {
            MoveCubeUnderIfOccupied(cube => cube.MoveForward());
            base.MoveForward();
        }

        public override void MoveBackward()
        {
            MoveCubeUnderIfOccupied(cube => cube.MoveBackward());
            base.MoveBackward();
        }
    }
}