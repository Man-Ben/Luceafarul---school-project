using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [Header ("Set a button for loading")]
    [SerializeField] Button load;
    

    void Awake()
    {
        load.onClick.AddListener(Load);
    }    

    [Description ("Loads the first scene or the saved scene when called")]
    void Load()
    {
        SceneManager.LoadScene(1);
    }

}
