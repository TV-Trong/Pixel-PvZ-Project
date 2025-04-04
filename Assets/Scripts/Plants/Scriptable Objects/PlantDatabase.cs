using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDatabase", menuName = "Create Plant Database")]
public class PlantDatabase : ScriptableObject
{
    public List<GameObject> plantPrefabs;

    public GameObject GetPlantPrefab(string plantName)
    {
        foreach (GameObject plant in plantPrefabs)
        {
            if (plant.name == plantName)
                return plant;
        }
        return null;
    }
}
