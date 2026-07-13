using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{    
    [Header ("Set a button for going back")]
    [SerializeField] Button back;
    [Space]

    [Header ("Set Menu Fields")]
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject loadAndCreate;
    [SerializeField] GameObject loadMenu;

    enum CurrentMenu
    {
        Settings,
        Manager,
        Load
    }

    CurrentMenu currentMenu;

    void Awake()
    {
        back.onClick.AddListener(OnBackClicked);
    }

    void OnBackClicked()
    {

        CheckWhichMenu();

        switch(currentMenu)
        {
            case CurrentMenu.Settings:
                settingsMenu.SetActive(false);
                startMenu.SetActive(true);
                gameObject.SetActive(false);
                break;
            case CurrentMenu.Manager:
                loadAndCreate.SetActive(false);
                startMenu.SetActive(true);
                gameObject.SetActive(false);
                break;
            case CurrentMenu.Load:
                loadMenu.SetActive(false);
                loadAndCreate.SetActive(true);
                break;
        }
    }

    void CheckWhichMenu()
    {
        if(settingsMenu.activeInHierarchy)
            currentMenu = CurrentMenu.Settings;
        else
            if(loadAndCreate.activeInHierarchy)
                currentMenu = CurrentMenu.Manager;
        else
            if(loadMenu.activeInHierarchy)
                currentMenu = CurrentMenu.Load;
    }
}
