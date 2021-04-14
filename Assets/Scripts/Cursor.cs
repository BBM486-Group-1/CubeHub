

using UnityEngine;

public class Cursor : Cube
{
    [SerializeField] private bool isActive;
    
    private static readonly int ColorPropertyName = Shader.PropertyToID("_Color");

    public void Toggle()
    {
        isActive = !isActive;
        ToggleColor();
    }
    
    private void ToggleColor()
    {
        foreach (Transform child in _gameObject.transform)
        { 
            // Get the Renderer component from the new cube
            var cubeRenderer = child.gameObject.GetComponent<Renderer>();

            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor(ColorPropertyName, IsActive() ? Color.red : Color.green); 
        }
    }

    public bool IsActive()
    {
        return isActive;
    }
}