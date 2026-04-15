using UnityEngine;
using UnityEngine.UI;

public class GameManagerMenu : MonoBehaviour
{
    [SerializeField] GameObject gameManagerMenu;
    [SerializeField] GameObject createGameMenu;
    [SerializeField] GameObject loadMenu;
    [SerializeField] GameObject back;

    [SerializeField] Button createMenuButton;
    [SerializeField] Button loadMenuButton;

    void Awake()
    {
        createMenuButton.onClick.AddListener(OnCreateMenuButtonPressed);
        loadMenuButton.onClick.AddListener(OnLoadMenuButtonPressed);
    }

    void OnCreateMenuButtonPressed()
    {
        gameManagerMenu.SetActive(false);
        back.SetActive(false);
        createGameMenu.SetActive(true);
    }
    void OnLoadMenuButtonPressed()
    {
        /*
        Inactivate the load menu. Write an if-statement to check if there's a file to load. If the file exists set the menu active. 
        */
        gameManagerMenu.SetActive(false);
        loadMenu.SetActive(true);
    }
}
