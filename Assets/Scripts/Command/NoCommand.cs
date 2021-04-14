using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCommand :  ICommand
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ICommand.Execute(){}
    void ICommand.Undo(){}
    
}
