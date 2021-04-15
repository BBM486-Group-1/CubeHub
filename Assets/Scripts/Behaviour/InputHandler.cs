using System.Collections.Generic;
using Domain.Command;
using UnityEngine;
using Cursor = Domain.Object.Cursor;

namespace Behaviour
{
    public class InputHandler : MonoBehaviour
    {
        public enum InputType
        {
            KeyDown,
            KeyHold,
            KeyUp
        };

        private Dictionary<InputType, Dictionary<KeyCode, ICommand>> _commands;

        [SerializeField] private CursorController cursorController;

        // Start is called before the first frame update
        void Start()
        {
            _commands = new Dictionary<InputType, Dictionary<KeyCode, ICommand>>();

            Cursor cursor = cursorController.GetCursor();

            RegisterCommand(InputType.KeyDown, KeyCode.A, new MoveLeftCommand(cursor));
            RegisterCommand(InputType.KeyDown, KeyCode.D, new MoveRightCommand(cursor));
            RegisterCommand(InputType.KeyDown, KeyCode.W, new MoveForwardCommand(cursor));
            RegisterCommand(InputType.KeyDown, KeyCode.S, new MoveBackwardCommand(cursor));
            RegisterCommand(InputType.KeyDown, KeyCode.R, new MoveUpCommand(cursor));
            RegisterCommand(InputType.KeyDown, KeyCode.F, new MoveDownCommand(cursor));
            RegisterCommand(InputType.KeyDown, KeyCode.Space, new ToggleSelectCommand(cursor));
        } 
        
        // Update is called once per frame
        void Update()
        {
            foreach (var inputType in _commands.Keys)
            {
                foreach (var key in _commands[inputType].Keys)
                {
                    // TODO: Use delegates maybe?
                    switch (inputType)
                    {
                        case InputType.KeyDown:
                            if (Input.GetKeyDown(key))
                                OnKeyEvent(inputType, key);
                            break;
                        case InputType.KeyHold:
                            if (Input.GetKey(key))
                                OnKeyEvent(inputType, key);
                            break;
                        case InputType.KeyUp:
                            if (Input.GetKeyUp(key))
                                OnKeyEvent(inputType, key);
                            break;
                    }
                }
            }
        }

        public void RegisterCommand(InputType inputType, KeyCode key, ICommand command)
        {
            if (!_commands.ContainsKey(inputType)) _commands[inputType] = new Dictionary<KeyCode, ICommand>();
            _commands[inputType][key] = command;
        }

        public void OnKeyEvent(InputType inputType, KeyCode key)
        {
            _commands[inputType][key].Execute();
            
        }

        public void UndoKeyPressed()
        {
        }
    }
}