using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Behaviour
{
    public class MainMenu : MonoBehaviour
    {
        bool _isInputChangeActive = false;
        public static KeyCode[] Inputs;

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

        public void ChangeInput(Button button)
        {
            button.Select();
            activeButton = button;
            _isInputChangeActive = true;
        }

        public void DetectPressedKeyOrButton()
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    Debug.Log("KeyCode down: " + kcode);
                    _isInputChangeActive = false;
                    eventSystem.SetSelectedGameObject(null);
                    activeButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = kcode.ToString();
                }
            }

            LoadInputs();
        }

        void Start()
        {
            LoadInputs();
        }

        void Update()
        {
            if (this._isInputChangeActive)
            {
                DetectPressedKeyOrButton();
            }
        }

        KeyCode StringToKeyCode(string key)
        {
            KeyCode thisKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), key);
            return thisKeyCode;
        }

        void LoadInputs()
        {
            Button[] buttons = GameObject.Find("Buttons").GetComponentsInChildren<Button>(true);
            int buttonsNumber = buttons.Length;
            Inputs = new KeyCode[buttonsNumber];

            for (int i = 0; i < buttonsNumber; i++)
            {
                string currentButtonText = buttons[i].GetComponentInChildren<TMP_Text>().text;
                KeyCode currentKeyCode = StringToKeyCode(currentButtonText);
                Inputs[i] = currentKeyCode;
            }


            if (GameObject.Find("MainMenu") && GameObject.Find("MainMenu").activeSelf)
                GameObject.Find("OptionsMenu").SetActive(false);
        }
    }
}