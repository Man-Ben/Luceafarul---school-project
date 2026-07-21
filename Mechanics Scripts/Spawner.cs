using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);

            if(Pool.Instance != null)
               Spawn();

            
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    void Spawn()
    {
        int possibility = Random.Range(1, 100);

        GameObject gotObject;
        GameObject fireProtection;

        switch(possibility)
        {
            case <= 80:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Obstacle);
            break;

            case > 80 and <= 95:

                if(HpManager.Instance.healthState == HpManager.HealthState.Damaged && JsonManager.Instance.playerData.difficulty != "Hard")
                    gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Recovery);
                else
                    gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Obstacle);

                if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    fireProtection = Pool.Instance.GivePooledObject(Pool.PoolState.FireProtection);

                    if(fireProtection != null)
                        fireProtection.transform.position = new Vector2(gameObject.transform.position.x, GetSpawn());
                }
                    
            break;

            case > 95:
                gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.Collectible);
            break;
        }

    if(gotObject != null)
        gotObject.transform.position = new Vector2(gameObject.transform.position.x, GetSpawn());
    }

    float GetSpawn()
    {
        float minY = -5;
        float maxY = 0;

        float y = Random.Range(minY, maxY);

        return y;
    }

}
