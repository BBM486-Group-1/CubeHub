using System.Collections.Generic;
using Domain.Command;
using UnityEngine;
using MoveRightCommand = Domain.Command.MoveRightCommand;


namespace Behaviour
{
    public class InputHandler : MonoBehaviour
    { 
        private Dictionary<string, ICommand> _commands;

        [SerializeField] private CursorController cursorController;
    
        // Start is called before the first frame update
        void Start()
        {
            _commands = new Dictionary<string, ICommand>();
        
            RegisterCommand("a", new MoveLeftCommand(cursorController.GetCursor()));
            RegisterCommand("d", new MoveRightCommand(cursorController.GetCursor())); 
            RegisterCommand(" ", new ToggleSelectCommand(cursorController.GetCursor()));
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

        public void RegisterCommand(string key, ICommand command){ 
            _commands[key] = command;
        }

        public void KeyPressed(string key) {
            _commands[key].Execute();
        
            // this.undoButton = buttons[buttonNo];
        }

        public void UndoKeyPressed() {
         
        }

    }
}
