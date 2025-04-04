using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    public static PoolingSystem instance;

    [SerializeField] List<ObjectToPool> objectToPool = new List<ObjectToPool>();
    Dictionary<string, ObjectToPool> stringToPoolDict = new Dictionary<string, ObjectToPool>();

    private void Awake()
    {
        instance = this;

        foreach (ObjectToPool pooledObject in objectToPool)
        {
            stringToPoolDict[pooledObject.objectName] = pooledObject;

            for (int i = 0; i < pooledObject.amount; i++)
            {
                GameObject newObject = Instantiate(pooledObject.objectPrefab);
                newObject.transform.SetParent(pooledObject.holder, true);
                newObject.SetActive(false);
                pooledObject.listObject.Add(newObject);
            }
        }
    }

    public GameObject GetPooledObjects(string poolName)
    {
        for (int i = 0; i < stringToPoolDict[poolName].listObject.Count; i++)
        {
            if (!stringToPoolDict[poolName].listObject[i].activeInHierarchy) 
                return stringToPoolDict[poolName].listObject[i];
        }

        Debug.LogWarning("Pool not large enough!");
        return null;
    }
}

[Serializable]
public class ObjectToPool
{
    public GameObject objectPrefab;
    public string objectName;
    public int amount;
    public Transform holder;
    [HideInInspector] public List<GameObject> listObject = new List<GameObject>();
}
