using UnityEngine;

namespace Domain.Object
{
    public class Cursor : AbstractMovable
    {
        public Cursor(GameObject gameObject) : base(gameObject)
        {
            _isActive = false;
        }
         
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
    }
}