using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header ("Forces")]
    [Range(0.0f, 20.0f)]
    [SerializeField] float ascendForce;

    [Space]

    [Header ("Bounds")]
    [Tooltip ("This is used to inactivate the bottom bound for falling")]
    [SerializeField] GameObject bottomBound;
    
    Rigidbody2D playerRb;
    
    public enum PlayerState
    {
        Neutral,
        hasFireProtection,
    }

    [Space]

    [Header ("State")]
    public PlayerState playerState;

    public static PlayerController Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            Fly();

            if(UIManager.Instance.gameState == UIManager.GameState.GameOver)
                bottomBound.SetActive(false);
    }

    void Fly()
    {
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
            if(Input.GetMouseButtonDown(0))
                playerRb.AddForce(Vector2.up * ascendForce, ForceMode2D.Impulse);
    }

    IEnumerator InactivateFireProtection()
    {
        yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);
        
        yield return new WaitForSecondsRealtime(5);
        playerState = PlayerState.Neutral;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
        {
            if(ShieldScript.Instance.shieldState != ShieldScript.ShieldState.Active)
            {
                if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    if(collision.CompareTag("Lava") && playerState == PlayerState.Neutral)
                    {
                        HpManager.Instance.InactivateHealth();
                    }
                    
                    if(collision.CompareTag("FireProtection") && playerState == PlayerState.Neutral)
                    {
                        playerState = PlayerState.hasFireProtection;
                        StartCoroutine(InactivateFireProtection());
                    }
                }
                
                if(collision.CompareTag("Obstacle"))
                {
                    HpManager.Instance.InactivateHealth();
                }
                else 
                    if(collision.CompareTag("Recovery"))
                    {
                        HpManager.Instance.Healing();
                    }
                else
                    if(collision.CompareTag("Collectible"))
                    {
                        GameProgress.Instance.UpdateProgressBar();  
                    }
            }         

            if(!collision.CompareTag("Lava"))
                collision.gameObject.SetActive(false);
        }   
    }
}
