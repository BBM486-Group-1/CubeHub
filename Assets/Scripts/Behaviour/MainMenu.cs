using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    bool isInputChangeActive = false;
    public static KeyCode[] inputs;


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
        loadInputs();
    }

    void Start()
    {
        
        loadInputs();
    }
    void Update()
    {
        if (this.isInputChangeActive)
        {
            detectPressedKeyOrButton();
        }
    }

    KeyCode stringToKeyCode(string key)
    {
        KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
        return thisKeyCode;
    }


    void loadInputs()
    {
        
        Button[] buttons = GameObject.Find("Buttons").GetComponentsInChildren<Button>(true);
        int buttonsNumber = buttons.Length;
        inputs = new KeyCode[buttonsNumber];

        for(int i = 0; i < buttonsNumber; i++)
        {
            string currentButtonText = buttons[i].GetComponentInChildren<TMP_Text>().text;
            KeyCode currentKeyCode = stringToKeyCode(currentButtonText);
            inputs[i] = currentKeyCode;
        }


        if(GameObject.Find("MainMenu") && GameObject.Find("MainMenu").activeSelf)
            GameObject.Find("OptionsMenu").SetActive(false);
    }
}


