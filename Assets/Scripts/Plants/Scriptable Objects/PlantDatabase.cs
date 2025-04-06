using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDatabase", menuName = "Create Plant Database")]
public class PlantDatabase : ScriptableObject
{
    public List<PlantDataList> plantDataList;

    public Dictionary<int, PlantDataList> IDToPlantDataDict;

    public void Initialize()
    {
        for (int i = 0; i < plantDataList.Count; i++)
        {
            plantDataList[i].plantID = i;
        }

        if (IDToPlantDataDict == null)
        {
            IDToPlantDataDict = new Dictionary<int, PlantDataList>();

            foreach (var plant in plantDataList)
            {
                if (!IDToPlantDataDict.ContainsKey(plant.plantID))
                    IDToPlantDataDict.Add(plant.plantID, plant);
                else
                    Debug.LogWarning($"Duplicate plantID found: {plant.plantID} in database.");
            }
        }
    }

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
    [HideInInspector] public int plantID;
    public string plantName;
    public bool isUnlocked;
    public GameObject plantPrefab;
    public PlantBase_SO plantData;
}
