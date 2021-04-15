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
            KeyCode[] inputs = MainMenu.inputs;
            Debug.Log(inputs[0]);
            RegisterCommand(InputType.KeyDown, inputs[0], new MoveLeftCommand(cursor));
            RegisterCommand(InputType.KeyDown, inputs[1], new MoveRightCommand(cursor));
            RegisterCommand(InputType.KeyDown, inputs[2], new MoveForwardCommand(cursor));
            RegisterCommand(InputType.KeyDown, inputs[3], new MoveBackwardCommand(cursor));
            RegisterCommand(InputType.KeyDown, inputs[4], new MoveUpCommand(cursor));
            RegisterCommand(InputType.KeyDown, inputs[5], new MoveDownCommand(cursor));
            RegisterCommand(InputType.KeyDown, inputs[6], new ToggleSelectCommand(cursor));
        } 
        
        // Update is called once per frame
        void Update()
        {
            if (!PauseMenu.GameIsPaused)
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