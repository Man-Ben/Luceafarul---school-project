using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CreateGameMenu : MonoBehaviour
{

    [SerializeField] GameObject gameManagerMenu;
    [SerializeField] GameObject createGameMenu;
    [SerializeField] GameObject back;

    [SerializeField] Button creatButton;
    [SerializeField] Button cancelButton;


    [SerializeField] TMP_InputField gameNameInput;
    [SerializeField] TMP_Dropdown difficulty;

    enum DifficultyState
    {
        Easy,
        Medium,
        Hard
    }


    void Awake()
    {
        AddListenerToUI();

        //Create an instance for data transfer
    }

    void AddListenerToUI()
    {
        creatButton.onClick.AddListener(OnCreateButtonPressed);
        cancelButton.onClick.AddListener(OnCancelButtonPressed);
        difficulty.onValueChanged.AddListener(OnDropDownValueChanged);
        gameNameInput.onEndEdit.AddListener(OnTextWrote);

    }

    void OnCreateButtonPressed()
    {
        SceneManager.LoadScene(1);
        //Save player's data (diff, name)
    }

    void OnCancelButtonPressed()
    {
        gameManagerMenu.SetActive(true);
        back.SetActive(true);
        createGameMenu.SetActive(false);
    }

    void OnDropDownValueChanged(int selected)
    {
        //Difficulty state set
        Debug.Log("Selected difficulty: " + selected);
    }

    void OnTextWrote(string text)
    {
        //Game name get
        Debug.Log("Written text: " + text);
    }

}
