using System.ComponentModel;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [Header ("Loading Buttons")]
    [SerializeField] Button load;

    [Header ("Difficulty Buttons")]
    [SerializeField] Button easy;
    [SerializeField] Button medium;
    [SerializeField] Button hard;

    public static LoadGame Instance {get; private set;}
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        AddListenerToUI();
    
        //FOR TESTING. DON'T FORGET TO DELETE!!
        JsonManager.Instance.ReadPlayerData("17-07-2026");
        Debug.Log("Last game's diff: " + JsonManager.Instance.playerData.difficulty);
    
    }

    void AddListenerToUI()
    {
        //load.onClick.AddListener(Load);
        easy.onClick.AddListener(() => SetDifficulty("Easy"));
        medium.onClick.AddListener(() => SetDifficulty("Medium"));
        hard.onClick.AddListener(() => SetDifficulty("Hard"));
    }    

    void SetDifficulty(string difficulty)
    {
        JsonManager.Instance.gameData = JsonManager.Instance.ReadGameConfig(difficulty);

        JsonManager.Instance.CreateSaving();

        JsonManager.Instance.playerData.difficulty = difficulty;

        SceneManager.LoadScene(1);
    } 

    [Description ("Loads the saved scene when called")]
    void Load()
    {
        JsonManager.Instance.ReadPlayerData("17-07-2026");
        SceneManager.LoadScene(1);
    }

}
