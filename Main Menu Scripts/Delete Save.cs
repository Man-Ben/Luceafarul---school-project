using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSave : MonoBehaviour
{
    [SerializeField] Button deleteButton;

    void Awake()
    {
        deleteButton.onClick.AddListener(Delete);
    }

    void Delete()
    {
        JsonManager.Instance.DeleteFile($"{GetComponentInChildren<TMP_Text>().text}.json");
        Destroy(gameObject);
    }
}
