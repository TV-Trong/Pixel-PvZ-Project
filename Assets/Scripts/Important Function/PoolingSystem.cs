using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    public List<ObjectToPool> objectToPool = new List<ObjectToPool>();

    private void Awake()
    {
        foreach (ObjectToPool pooledObject in objectToPool)
        {
            for (int i = 0; i < pooledObject.amount; i++)
            {
                GameObject newObject = Instantiate(pooledObject.objectPrefab);
                newObject.transform.SetParent(pooledObject.holder, true);
                newObject.SetActive(false);
                pooledObject.listObject.Add(newObject);
            }
        }
    }

    public GameObject GetPooledObjects(int index)
    {
        for (int i = 0; i < objectToPool[index].listObject.Count; i++)
        {
            if (!objectToPool[index].listObject[i].activeInHierarchy) return objectToPool[index].listObject[i];
        }
        return null;
    }
}

[Serializable]
public class ObjectToPool
{
    public GameObject objectPrefab;
    public int amount;
    public Transform holder;
    [HideInInspector] public List<GameObject> listObject = new List<GameObject>();
}
