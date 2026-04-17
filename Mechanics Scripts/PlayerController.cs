using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float ascendForce = 5;
    
    Rigidbody2D playerRb;

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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            playerRb.AddForce(Vector2.up * ascendForce, ForceMode2D.Impulse);
        }

    }

}
