using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    [SerializeField] float backGroundSpeed = 10;

    Vector2 ResetPosition = new Vector2(107.6f, 0);

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        transform.Translate(Vector2.left * backGroundSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BackgroundBound"))
            transform.position = ResetPosition;
    }

}
