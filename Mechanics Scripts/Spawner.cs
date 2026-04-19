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
            
            yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Resumed);

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
                if(PlayerController.Instance.playerState != PlayerController.PlayerState.HasRecovery)
                    gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Recovery);
                else
                    gotObject = null;
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
        float minY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;

        float y = Random.Range(minY, maxY);
        float lastSpawn = 0;
        float minGap = 2f;

        if(Mathf.Abs(y-lastSpawn) < minGap)
            y += minGap * Mathf.Sign(Random.value - 0.5f);

        lastSpawn = y;

        return y;
    }

}
