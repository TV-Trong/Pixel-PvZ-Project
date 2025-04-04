using System.Collections.Generic;
using UnityEngine;

public class SeedSlotSpawner : MonoBehaviour
{
    [SerializeField] PlantDatabase plantDatabase;
    [SerializeField] List<GameObject> seedSlots;

    //For debugging
    public List<string> chosenPlants = new List<string>();

    private void Start()
    {
        for (int i = 0; i < chosenPlants.Count; i++)
        {
            if (!seedSlots[i].activeInHierarchy)
            {
                seedSlots[i].SetActive(true);

                var plantChoosing = seedSlots[i].GetComponent<PlantChoosing>();

                foreach (var plant in plantDatabase.plantDataList)
                {
                    if (plant.plantName == chosenPlants[i])
                    {
                        plantChoosing.SetPlant(plant.plantData);
                        plantChoosing.SetupPlantUI();
                        break;
                    }
                }
            }
        }
    }
}
