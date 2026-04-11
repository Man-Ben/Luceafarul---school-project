using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


[SerializeField] private class StartMenu : MonoBehaviour
{

        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject gameManagerMenu;
        [SerializeField] private GameObject settingMenu;


        [SerializeField] private Button gameButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;

    void Awake()
    {
        AddListenerToUI();
    }

    void AddListenerToUI()
    {
        
    }

    void OnGameButtonPressed()
    {
        
    }

    void OnExitButtonPressed()
    {
        
    }

    void OnQuitButtonPressed()
    {
        
    }


}
