using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        while(UIManager.Instance.gameState != UIManager.GameState.GameOver)
        {
            int randomDelay = Random.Range(1, 2);
            
            yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);

            if(Pool.Instance != null)
               Spawn();

            
            yield return new WaitForSeconds(randomDelay);
        }
    }

    void Spawn()
    {
        int possibility = Random.Range(1, 100);

        GameObject gotObject;

        switch(possibility)
        {
            case <= 80:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Obstacle);
            break;

            case > 80 and <= 95:
                if(HpManager.Instance.healthState == HpManager.HealthState.Damaged)
                    gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Recovery);
                else
                    gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Obstacle);
            break;

            case > 95:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Collectible);
            break;
        }

    if(gotObject != null)
        gotObject.transform.position = new Vector2(20, GetSpawn());
    }

    float GetSpawn()
    {
        float minY = -5;
        float maxY = 0;

        float y = Random.Range(minY, maxY);

        return y;
    }

}
