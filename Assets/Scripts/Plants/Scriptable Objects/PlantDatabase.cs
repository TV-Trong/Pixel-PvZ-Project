using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDatabase", menuName = "Create Plant Database")]
public class PlantDatabase : ScriptableObject
{
    public List<PlantDataList> plantDataList;

    public GameObject GetPlantPrefab(string plantName)
    {
        foreach (var plant in plantDataList)
        {
            if (plant.plantName == plantName)
                return plant.plantPrefab;
        }
        return null;
    }
}


[Serializable]
public class PlantDataList
{
    public string plantName;
    public GameObject plantPrefab;
    public PlantBase_SO plantData;
}
