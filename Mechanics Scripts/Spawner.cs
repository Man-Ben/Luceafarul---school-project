using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    void Update()
    {
        if(Pool.Instance != null)
            Spawn();
    }

    void Spawn()
    {
        int possibility = Random.Range(1, 10);

        GameObject gotObject;

        switch(possibility)
        {
            case <= 6:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Obstacle);
            break;

            case > 6 and <= 8:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Recovery);
            break;

            case > 8:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Collectible);
            break;
        }

    if(gotObject != null)
        gotObject.transform.position = new Vector2(20, GetSpawn());
    }

    float GetSpawn()
    {
        float minY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;

        float direction = Random.value < 0.5f ? -1f : 1f;

        float lastSpawn = 0;

        float y = lastSpawn + direction * Random.Range(2, 4);

        y = Mathf.Clamp(y, minY, maxY);

        lastSpawn = y;

        return y;
    }

}
