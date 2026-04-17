using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    [SerializeField] float backGroundSpeed = 10;

    [SerializeField] List<Transform> panels;

    float width;
    Transform firstPanel;
    Transform lastPanel;
    Vector2 limit = new Vector2(-52, 0);

    void Start()
    {
        width = panels[0].GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        firstPanel = panels[0];
        lastPanel = panels[panels.Count - 1];
        
        transform.Translate(Vector2.left * backGroundSpeed * Time.deltaTime);

        if(firstPanel.transform.position.x < limit.x)
        {
            ResetPosition();
        }
        
    }

    void ResetPosition()
    {
        firstPanel.position = new Vector2(lastPanel.position.x + width, 0);

        panels.RemoveAt(0);
        panels.Add(firstPanel);
    }


}
