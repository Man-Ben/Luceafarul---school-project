using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Forces")]
    [Range(0.0f, 10.0f)]
    [SerializeField] float ascendForce;

    [Space]

    [Header ("Bounds")]
    [Tooltip ("This is used to inactivate the bottom bound, for falling imitation")]
    [SerializeField] GameObject bottomBound;

    [Space]

    [Header ("Shield")]
    [SerializeField] GameObject shield;
    
    Rigidbody2D playerRb;
    
    public enum PlayerState
    {
        Neutral,
        Damaged,
        ActiveShield,
    }

    [Space]

    [Header ("State")]
    public PlayerState playerState;

    public static PlayerController Instance;

    bool canReactivate;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        canReactivate = true;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            Fly();
            ActivateShield();

            if(UIManager.Instance.gameState == UIManager.GameState.GameOver)
                bottomBound.SetActive(false);
    }

    void Fly()
    {
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
            if(Input.GetMouseButtonDown(0))
                playerRb.AddForce(Vector2.up * ascendForce, ForceMode2D.Impulse);
    }

    IEnumerator ShieldCountDown()
    {
        yield return new WaitForSecondsRealtime(5);

        shield.SetActive(false);
        canReactivate = false;

        StartCoroutine(TimeForReactivateShield());
    }

    IEnumerator TimeForReactivateShield()
    {
        playerState = PlayerState.Neutral;
        yield return new WaitForSecondsRealtime(10);
        canReactivate = true;
    }

    void ActivateShield()
    {
        if(Input.GetMouseButtonDown(1) && playerState != PlayerState.ActiveShield && canReactivate)
        {
            shield.SetActive(true);
            playerState = PlayerState.ActiveShield;
            StartCoroutine(ShieldCountDown());   
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
        {
            if(playerState != PlayerState.ActiveShield)
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
            collision.gameObject.SetActive(false);
        }
        
    }
}
