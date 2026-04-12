using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    [SerializeField] Button backButton;

    [SerializeField] GameObject back;

    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject gameManagerMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject loadMenu;

    MenuState currentMenu;


    enum MenuState
    {
        GameManager,
        Settings,
        Load
    }

    void Awake()
    {
        backButton.onClick.AddListener(GoBack);
    } 

    void GoBack()
    {
        CheckMenu();

        switch(currentMenu)
        {
            case MenuState.GameManager:
                startMenu.SetActive(true);
                gameManagerMenu.SetActive(false);
                back.SetActive(false);
                break;

            case MenuState.Settings:
                startMenu.SetActive(true);
                settingsMenu.SetActive(false);
                back.SetActive(false);
                break;
            case MenuState.Load:
                startMenu.SetActive(true);
                loadMenu.SetActive(false);
                back.SetActive(false);
                break;
        }
    }

    void CheckMenu()
    {
        if(gameManagerMenu.activeInHierarchy)
            currentMenu = MenuState.GameManager;
        else if(settingsMenu.activeInHierarchy)
            currentMenu = MenuState.Settings;
        else if(loadMenu.activeInHierarchy)
            currentMenu = MenuState.Load;
    }
}
