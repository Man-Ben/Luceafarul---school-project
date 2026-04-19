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
        gameButton.onClick.AddListener(OnGameButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    void OnGameButtonClicked()
    {
        startMenu.SetActive(false);
        gameManagerMenu.SetActive(true);
        back.SetActive(true);
    }

    void OnSettingsClicked()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
        back.SetActive(true);
    }

    void OnQuitButtonClicked()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }


}
