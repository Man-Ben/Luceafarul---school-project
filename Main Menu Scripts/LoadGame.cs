using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] Button loadButton;

    void Awake()
    {
        loadButton.onClick.AddListener(LoadSave);
    }

    void LoadSave()
    {
        JsonManager.Instance.ReadPlayerData($"{GetComponentInChildren<TMP_Text>().text}.json");
        JsonManager.Instance.ReadGameConfig($"{JsonManager.Instance.playerData.difficulty}");

        JsonManager.Instance.saveFile = $"{GetComponentInChildren<TMP_Text>().text}.json";

        SceneManager.LoadScene(JsonManager.Instance.playerData.reachedScene);
    }
}
