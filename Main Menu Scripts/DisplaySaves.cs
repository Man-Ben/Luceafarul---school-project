using UnityEngine;
using TMPro;
public class DisplaySaves : MonoBehaviour
{
    [SerializeField] GameObject saveSlots;
    [SerializeField] Transform contentTransform;

    void Start()
    {
        JsonManager.Instance.GetEverySave();
        
        if(JsonManager.Instance.savings.Count == 0)
            return;

        for(int i = 0; i < JsonManager.Instance.savings.Count; i++)
        {
            GameObject obj = Instantiate(saveSlots, contentTransform);
            obj.GetComponentInChildren<TMP_Text>().text = JsonManager.Instance.savings[i];
        }
    }
}
