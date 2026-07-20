using System.ComponentModel;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour
{
    [Header ("Difficulty Buttons")]
    [SerializeField] Button easy;
    [SerializeField] Button medium;
    [SerializeField] Button hard;

    public static CreateGame Instance {get; private set;}
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        AddListenerToUI();
    }

    void AddListenerToUI()
    {
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
}
