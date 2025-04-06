using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    #region Setup

    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private float minSpawnInterval = 5f;
    [SerializeField] private float spawnInterval = 25f;

    private Vector2 spawnPosition;

    #endregion

    public void StartSpawningSun()
    {
        var initTime = Random.Range(minSpawnInterval, spawnInterval);

        InvokeRepeating(nameof(SpawnSun), initTime, spawnInterval);
    }

    private void SpawnSun()
    {
        spawnPosition = new Vector2(Random.Range(leftBound.position.x, rightBound.position.x), leftBound.position.y);

        var sun = PoolingSystem.instance.GetPooledObjects("Sun");
        var sunBehaviour = sun.GetComponent<SunBehaviour>();

        sunBehaviour.SetSunType(SunBehaviour.SunType.Natural);

        sun.transform.position = spawnPosition;
        sun.SetActive(true);
    }
}
