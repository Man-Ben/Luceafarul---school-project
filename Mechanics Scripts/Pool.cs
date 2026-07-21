using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pool : MonoBehaviour
{

    [Header ("Pools")]
    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledCollectibles;
    public List<GameObject> pooledRecoveries;
    public List<GameObject> pooledFireProtection;

    [Space]

    [Header ("Objects to pool")]

    [SerializeField] List<GameObject> obstaclesToPool;
    [SerializeField] List<GameObject> collectiblesToPool;
    [SerializeField] List<GameObject> recoveriesToPool;
    [SerializeField] List<GameObject> fireProtectionToPool;

    public enum PoolState
    {
        Obstacle,
        Collectible,
        Recovery,
        FireProtection,
    }

    [Space]

    [Header ("State")]
    public PoolState poolState;

    public static Pool Instance {get; private set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;

        PoolingObjects(obstaclesToPool, pooledObstacles, 20);
        PoolingObjects(collectiblesToPool, pooledCollectibles, 5);

        if(JsonManager.Instance.playerData.difficulty != "Hard")
            PoolingObjects(recoveriesToPool, pooledRecoveries, 10);

        if(SceneManager.GetActiveScene().buildIndex == 2)
            PoolingObjects(fireProtectionToPool, pooledFireProtection, 10);
        
    }

    void PoolingObjects(List<GameObject> objectToPool, List<GameObject> pooledObject, int amountToPool)
    {
        GameObject tmp;
        foreach(var objToPool in objectToPool)
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objToPool);
                tmp.SetActive(false);
                pooledObject.Add(tmp);
            }
    }

    GameObject GetPooledObjects(List<GameObject> objectsToGet)
    {
        int index = UnityEngine.Random.Range(0, objectsToGet.Count);
            if(!objectsToGet[index].activeSelf)
            {
                objectsToGet[index].SetActive(true);
                return objectsToGet[index];
            }
        

        return null;
    }

    public GameObject GivePooledObject(PoolState state)
    {
        switch(state)
        {
            case PoolState.Obstacle:
                return GetPooledObjects(pooledObstacles);

            case PoolState.Collectible:
                return GetPooledObjects(pooledCollectibles);

            case PoolState.Recovery:
                return GetPooledObjects(pooledRecoveries);
            
            case PoolState.FireProtection:
                return GetPooledObjects(pooledFireProtection);

            default: 
                return null;
            
        }
    }

}
