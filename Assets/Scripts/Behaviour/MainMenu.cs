using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public interface Command
{
    void execute();
};

public class UpCommand : Command
{
    public void execute()
    {
        Debug.Log("Up Command is called");
    }
}


public class MainMenu : MonoBehaviour
{
    bool isInputChangeActive = false;
    public Button activeButton;
    public EventSystem eventSystem;
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }   

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void changeInput(Button button)
    {
        button.Select();
        activeButton = button;
        isInputChangeActive = true;

    }
    public void detectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                Debug.Log("KeyCode down: " + kcode);
                isInputChangeActive = false;
                eventSystem.SetSelectedGameObject(null);
                activeButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = kcode.ToString();
            }
        }
        
    }

    void Update()
    {
        if (this.isInputChangeActive)
        {
            detectPressedKeyOrButton();
        }
    }
}


