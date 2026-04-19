using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    /*There will be a scrollview logic and a logic for the Delete and Load buttons. All this after the save system is created.
      Attention: when you implement the scrollview, don't forget to replace the saveAndDelete to a prefab!!!
    */

    [SerializeField] Button loadButton;
    [SerializeField] Button deleteButton;
    [SerializeField] Button yesButton;
    [SerializeField] Button cancelButton;


    [SerializeField] GameObject saveAndDelete;
    [SerializeField] GameObject confirmDeleteMessage;

    int loadedSceneIndex = 1;

    void Awake()
    {
        AddListenerToUI();
    }

    void AddListenerToUI()
    {
        loadButton.onClick.AddListener(OnLoadButtonClicked);
        deleteButton.onClick.AddListener(OnDeleteButtonClicked);
        yesButton.onClick.AddListener(OnYesButtonClicked);
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    void OnLoadButtonClicked()
    {
        //Load users data from file. Load the scene. With an instance send the read data to the loaded scene.
        SceneManager.LoadScene(loadedSceneIndex);
    }

    void OnDeleteButtonClicked()
    {
        confirmDeleteMessage.SetActive(true);
    }

    void OnYesButtonClicked()
    {
        Debug.Log("World Deleted!");
        //Add a method to delete the save file.
        confirmDeleteMessage.SetActive(false);
    }

    void OnCancelButtonClicked()
    {
        confirmDeleteMessage.SetActive(false);
    }
}
