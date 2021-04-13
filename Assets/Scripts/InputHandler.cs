using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    ICommand[] buttons;
    ICommand undoButton;

    [SerializeField] int buttonCount;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new ICommand[this.buttonCount];
        ICommand noCommand = new NoCommand();
        for(int i = 0; i< buttonCount; i++){
            buttons[i] = noCommand;
        }
        this.undoButton = noCommand;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCommand(int buttonNo, ICommand command){
        
        this.buttons[buttonNo] = command;
    }

    public void buttonPressed(int buttonNo) {
        this.buttons[buttonNo].execute();
        this.undoButton = buttons[buttonNo];
    }

    public void undoButtonPressed() {
        this.undoButton.undo();
    }

}
