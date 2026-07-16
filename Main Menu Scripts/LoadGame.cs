using System.ComponentModel;
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

    void Awake()
    {
        AddListenerToUI();
    }

    void AddListenerToUI()
    {
        load.onClick.AddListener(Load);
        easy.onClick.AddListener(() => SetDifficulty());
        medium.onClick.AddListener(() => SetDifficulty());
        hard.onClick.AddListener(() => SetDifficulty());
    }    

    void SetDifficulty()
    {
        SceneManager.LoadScene(1);
    }

    [Description ("Loads the saved scene when called")]
    void Load()
    {
        SceneManager.LoadScene(1);
    }

}
