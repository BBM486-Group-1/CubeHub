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
