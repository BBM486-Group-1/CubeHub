using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] protected GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveLeft()
    {
        // TODO: Lerp these, instead of instantly translating.
        _gameObject.transform.Translate(-1, 0, 0);
    }
    
    public void MoveRight()
    {
        _gameObject.transform.Translate(1, 0, 0); 
        
        // TODO: This is the code for changing color of the cursor
        foreach (Transform child in _gameObject.transform)
        {

            // Get the Renderer component from the new cube
            var cubeRenderer = child.gameObject.GetComponent<Renderer>();

            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.red);
            
        }
    }
    public void MoveUp()
    {
        _gameObject.transform.Translate(0, 1, 0);
    }
    
    public void MoveDown()
    {
        _gameObject.transform.Translate(1, -1, 0);
    }
    public void MoveForward()
    {
        _gameObject.transform.Translate(0, 0, 1);
    }
    
    public void MoveBackward()
    {
        _gameObject.transform.Translate(0, 0, -1);
    }
}
