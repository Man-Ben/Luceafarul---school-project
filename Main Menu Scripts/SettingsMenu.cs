using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown languageDropDown;

    void Awake()
    {
        languageDropDown.onValueChanged.AddListener(OnLanguageDropDownValueChanged);
    }

    void OnLanguageDropDownValueChanged(int value)
    {
        /*
        Later in this project write a save system that saves the option selected by the user, than at the start loads it. Onchange => direct save;
        Don't forget about the language changing algorithm.
        */

        Debug.Log("Language was changed");
        Debug.Log("Data saved to SettingsFile");
    }

}
