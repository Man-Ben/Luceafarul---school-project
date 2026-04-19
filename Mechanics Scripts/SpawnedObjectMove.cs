using UnityEngine;

public class SpawnedObjectMove : MonoBehaviour
{
    [SerializeField] float objectSpeed;
    float boundX;

    float playerPos;
    Rigidbody2D objectRb;

    void Awake()
    {
        boundX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        objectRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        OutOfBounds();
    }

    void Move()
    {
        if(UIManager.Instance.gameState == UIManager.GameState.GameOver || UIManager.Instance.gameState == UIManager.GameState.Paused)
        {
            objectRb.linearVelocity = Vector2.zero;
            objectRb.angularVelocity = 0f;
        }
        else
            objectRb.linearVelocity = Vector2.left * objectSpeed;
    }

    void OutOfBounds()
    {
        if(gameObject.transform.position.x < boundX)
        {
            if(gameObject.CompareTag("Obstacle"))
                GameProgress.Instance.UpdateScore(10);

            gameObject.SetActive(false);
            gameObject.transform.position = new Vector2(20, 0);
            objectRb.linearVelocity = Vector2.zero;
            objectRb.angularVelocity = 0f;
        }
    }
}
