using UnityEngine;

public class SpawnedObjectMove : MonoBehaviour
{
    [SerializeField] float objectSpeed;

    float playerPos;
    Rigidbody2D objectRb;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        objectRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        OutOfBounds();
    }

    void Move()
    {
        objectRb.linearVelocity = Vector2.left * objectSpeed;
    }

    void OutOfBounds()
    {
        if(gameObject.transform.position.x < playerPos-10)
        {
            Destroy(gameObject);
        }
    }
}
