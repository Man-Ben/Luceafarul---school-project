using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShieldScript : MonoBehaviour
{
    [Header ("Mobile Button")]
    [SerializeField] Button shieldButton;

    [Space]

    [Header ("Shield")]
    [SerializeField] GameObject shield;

    public enum ShieldState
    {
        InActive,
        Active,
        WaitForActive,
    }

    [Space]
    [Header ("Shield state")]
    public ShieldState shieldState;

    public static ShieldScript Instance {get; private set;}

    bool onMobile = false;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.isEditor)
        {
                onMobile = true;
                shieldButton.gameObject.SetActive(true);
                shieldButton.onClick.AddListener(OnShieldButtonClicked);
        }
    }

    void Update()
    {
        ActivateShield();
    }

    IEnumerator ShieldCountDown()
    {
        yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);

        yield return new WaitForSecondsRealtime(5);

        shield.SetActive(false);
        shieldState = ShieldState.Active;

        StartCoroutine(TimeForReactivateShield());
    }

    IEnumerator TimeForReactivateShield()
    {
        yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);
        
        shieldState = ShieldState.WaitForActive;
        yield return new WaitForSecondsRealtime(10);
        shieldState = ShieldState.InActive;

        if(onMobile)
            shieldButton.gameObject.SetActive(true);
    }

    void ActivateShield()
    {
        if(Input.GetMouseButtonDown(1) && shieldState == ShieldState.InActive)
        {
            shield.SetActive(true);
            shieldState = ShieldState.Active;
            StartCoroutine(ShieldCountDown());   
        }

    }

    void OnShieldButtonClicked()
    {
        if(shieldState == ShieldState.InActive)
        {
            shield.SetActive(true);
            shieldButton.gameObject.SetActive(false);
            shieldState = ShieldState.Active;

            StartCoroutine(ShieldCountDown());
        }
    }
}
