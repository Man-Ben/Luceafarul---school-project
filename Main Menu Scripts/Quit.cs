using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [Header ("Set a button for quitting")]
    [SerializeField] Button quitButton;

    void Awake()
    {
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    void OnQuitPressed()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
