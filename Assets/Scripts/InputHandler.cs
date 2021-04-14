using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;
using UnityEngine.Serialization;
using MoveRightCommand = Command.MoveRightCommand;


public class InputHandler : MonoBehaviour
{ 
    private Dictionary<string, ICommand> _commands;

    [SerializeField] private Cursor cursor;
    
    // Start is called before the first frame update
    void Start()
    {
        _commands = new Dictionary<string, ICommand>();
        
        SetCommand("a", new MoveLeftCommand(cursor));
        SetCommand("d", new MoveRightCommand(cursor)); 
        SetCommand(" ", new ToggleSelectCommand(cursor));
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
        _commands[key] = command;
    }

    public void KeyPressed(string key) {
        _commands[key].Execute();
        
        // this.undoButton = buttons[buttonNo];
    }

    public void UndoKeyPressed() {
         
    }

}
