using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float ascendForce = 5;

    [SerializeField] GameObject bottomBound;
    
    Rigidbody2D playerRb;

    public enum PlayerState
    {
        Neutral,
        Death,
        HasRecovery,
        Collected,

    }

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

    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
            Fly();
    }

    void Fly()
    {
        if(playerState != PlayerState.Death && UIManager.Instance.gameState != UIManager.GameState.Paused)
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                playerRb.AddForce(Vector2.up * ascendForce, ForceMode2D.Impulse);
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle") && UIManager.Instance.gameState == UIManager.GameState.Resumed)
        {
            playerState = PlayerState.Death;
            bottomBound.SetActive(false);
        }
        else 
            if(collision.CompareTag("Recovery"))
                playerState = PlayerState.HasRecovery;
        else
            if(collision.CompareTag("Collectible"))
                playerState = PlayerState.Collected;

    }

}
