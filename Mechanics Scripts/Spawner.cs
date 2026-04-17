using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] List<GameObject> collectible;
    [SerializeField] List<GameObject> obstacle;
    [SerializeField] List<GameObject> recovery;
    
    void Start()
    {
        StartCoroutine(SpawnDelayObstacle());
        StartCoroutine(SpawnDelayCollectible());
        StartCoroutine(SpawnDelayRecovery());
    }

    void Spawn(List<GameObject> toSpawn)
    {
        Instantiate(toSpawn[Random.Range(0, toSpawn.Count)], new Vector2(20, Random.Range(-2.9f, 3.5f)), Quaternion.identity);
    }

    IEnumerator SpawnDelayObstacle()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Spawn(obstacle);
        }
        
    }
    IEnumerator SpawnDelayCollectible()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            Spawn(collectible);
        }
        
    
    }
    IEnumerator SpawnDelayRecovery()
    {
        while(true)
        {
            yield return new WaitForSeconds(7);
            Spawn(recovery);
        }
        
    }

}
