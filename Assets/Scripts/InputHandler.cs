using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;
using MoveRightCommand = Command.MoveRightCommand;


public class InputHandler : MonoBehaviour
{ 
    private Dictionary<string, ICommand> _commands;

    [SerializeField] private Cursor _cursor;
    
    // Start is called before the first frame update
    void Start()
    {
        _commands = new Dictionary<string, ICommand>();
        
        SetCommand("a", new MoveLeftCommand(_cursor));
        SetCommand("d", new MoveRightCommand(_cursor)); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (_commands.ContainsKey(Input.inputString))
            {
                KeyPressed(Input.inputString);
            }
        }
    }

    public void SetCommand(string key, ICommand command){ 
        this._commands[key] = command;
    }

    public void KeyPressed(string key) {
        this._commands[key].Execute();
        
        // this.undoButton = buttons[buttonNo];
    }

    public void UndoKeyPressed() {
         
    }

}
