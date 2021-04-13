using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCommand : MonoBehaviour, ICommand
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ICommand.execute(){}
    void ICommand.undo(){

    }
}
