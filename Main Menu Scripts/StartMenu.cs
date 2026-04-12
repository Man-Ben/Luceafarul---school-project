using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Actions;
using UnityEditor;


public class StartMenu : MonoBehaviour
{

        [SerializeField] GameObject startMenu;
        [SerializeField] GameObject gameManagerMenu;
        [SerializeField] GameObject settingsMenu;

        [SerializeField] GameObject back;

        [SerializeField] Button gameButton;
        [SerializeField] Button settingsButton;
        [SerializeField] Button quitButton;

    void Awake()
    {
        AddListenerToUI();
    }

    void AddListenerToUI()
    {
        gameButton.onClick.AddListener(OnGameButtonPressed);
        settingsButton.onClick.AddListener(OnSettingsPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    void OnGameButtonPressed()
    {
        startMenu.SetActive(false);
        gameManagerMenu.SetActive(true);
        back.SetActive(true);
    }

    void OnSettingsPressed()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
        back.SetActive(true);
    }

    void OnQuitButtonPressed()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }


}
