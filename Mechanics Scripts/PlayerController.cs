using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Forces")]
    [Range(0.0f, 10.0f)]
    [SerializeField] float ascendForce;

    [Space]

    [Header ("Bounds")]
    [SerializeField] GameObject bottomBound;
    
    Rigidbody2D playerRb;
    
    public enum PlayerState
    {
        Neutral,
        HasRecovery,
        Collected,
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

    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            Fly();
    }

    void Fly()
    {
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
            if(Input.GetMouseButtonDown(0))
                playerRb.AddForce(Vector2.up * ascendForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle") && UIManager.Instance.gameState == UIManager.GameState.Neutral)
        {
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
