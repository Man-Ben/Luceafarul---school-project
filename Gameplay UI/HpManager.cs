using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] List<GameObject> health;

    int totalHealth;
    public int remainingHealth;

    
    public enum HealthState
    {
        FullHealth,
        Damaged,
    }

    [Space]
    [Header ("State")]
    public HealthState healthState;

    public static HpManager Instance {get; private set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        totalHealth = JsonManager.Instance.gameData.maxHP;

        if(JsonManager.Instance.playerData.currentHP == 0)
            remainingHealth = totalHealth;
        else
            remainingHealth = JsonManager.Instance.playerData.currentHP;

        ActivateHealth();
    }

    void Update()
    {
        if(remainingHealth != totalHealth)
            healthState = HealthState.Damaged;
        else
            healthState = HealthState.FullHealth;
    }

    void ActivateHealth()
    {
        for(int i = 0; i < totalHealth; i++)
        {        
            if(JsonManager.Instance.playerData.currentHP != 0)
                if(i == JsonManager.Instance.playerData.currentHP)
                    break;

            health[i].gameObject.SetActive(true);
        }
            
    }

    public void InactivateHealth()
    {
        remainingHealth--;
        health[remainingHealth].gameObject.SetActive(false);

        healthState = HealthState.Damaged;
        

        if(remainingHealth == 0)
            UIManager.Instance.GameOver();
    }

    public void Healing()
    {
        if(remainingHealth == totalHealth)
        {
            healthState = HealthState.FullHealth;
            return;
        }

        health[remainingHealth].gameObject.SetActive(true);
        remainingHealth++;
    }
}
