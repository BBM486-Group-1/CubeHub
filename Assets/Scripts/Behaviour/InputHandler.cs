using System.Collections.Generic;
using Domain.Command;
using UnityEngine;


namespace Behaviour
{
    public class InputHandler : MonoBehaviour
    {
        private Dictionary<KeyCode, ICommand> _commands;

        [SerializeField] private CursorController cursorController;

        [SerializeField] private FlyCamera camera;

        // Start is called before the first frame update
        void Start()
        {
            _commands = new Dictionary<KeyCode, ICommand>();

            RegisterCommand(KeyCode.A, new MoveLeftCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.D, new MoveRightCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.W, new MoveForwardCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.S, new MoveBackwardCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.R, new MoveUpCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.F, new MoveDownCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.Space, new ToggleSelectCommand(cursorController.GetCursor()));
            RegisterCommand(KeyCode.LeftArrow, new MoveLeftCommand(camera));
            RegisterCommand(KeyCode.RightArrow, new MoveRightCommand(camera));
            RegisterCommand(KeyCode.UpArrow, new MoveForwardCommand(camera));
            RegisterCommand(KeyCode.DownArrow, new MoveBackwardCommand(camera));
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            { 
            }
        }
        
        void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey && e.type == EventType.KeyDown)
            {
                Debug.Log("Detected key code: " + e.keyCode);
                if (_commands.ContainsKey(e.keyCode))
                {
                    KeyPressed(e.keyCode);
                }
            }
        }

        public void RegisterCommand(KeyCode key, ICommand command)
        {
            _commands[key] = command;
        }

        public void KeyPressed(KeyCode key)
        {
            _commands[key].Execute();

            // this.undoButton = buttons[buttonNo];
        }

        public void UndoKeyPressed()
        {
        }
    }
}