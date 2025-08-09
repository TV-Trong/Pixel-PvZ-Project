using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject zombiePrefab;
    public float spawnInterval = 2f;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), 30f, spawnInterval);
    }

    private void Spawn()
    {
        var spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        var zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
    }
}
