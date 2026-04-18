using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance {get; private set;}
    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledCollectibles;
    public List<GameObject> pooledRecoveries;

    [SerializeField] List<GameObject> obstaclesToPool;
    [SerializeField] List<GameObject> collectiblesToPool;
    [SerializeField] List<GameObject> recoveriesToPool;

    public enum PoolState
    {
        Obstacle,
        Collectible,
        Recovery
    }

    public PoolState poolState;

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
        PoolingObjects(recoveriesToPool, pooledRecoveries, 10);
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

            default: 
                return null;
            
        }
    }

}
