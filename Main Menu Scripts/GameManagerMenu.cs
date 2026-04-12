using UnityEngine;
using UnityEngine.UI;

public class GameManagerMenu : MonoBehaviour
{
    [SerializeField] GameObject gameManagerMenu;
    [SerializeField] GameObject createGameMenu;
    [SerializeField] GameObject loadMenu;
    [SerializeField] GameObject back;

    [SerializeField] Button createButton;
    [SerializeField] Button loadButton;

    void Awake()
    {
        createButton.onClick.AddListener(OnCreateButtonPressed);
        loadButton.onClick.AddListener(OnLoadButtonPressed);
    }

    void OnCreateButtonPressed()
    {
        gameManagerMenu.SetActive(false);
        back.SetActive(false);
        createGameMenu.SetActive(true);
    }
    void OnLoadButtonPressed()
    {
        gameManagerMenu.SetActive(false);
        loadMenu.SetActive(true);
    }
}
