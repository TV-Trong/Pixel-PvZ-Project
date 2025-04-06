using System.Collections.Generic;
using UnityEngine;

public class SeedSlotManager : MonoBehaviour
{
    [SerializeField] PlantDatabase plantDatabase;
    [SerializeField] List<GameObject> seedSlots;

    //For debugging
    public List<int> chosenPlantsID = new List<int>();

    public void UpdateChosenPlant()
    {
        for (int i = 0; i < seedSlots.Count; i++)
        {
            if (i < chosenPlantsID.Count)
            {
                seedSlots[i].SetActive(true);

                var plantChoosing = seedSlots[i].GetComponent<SeedSlot>();
                var plant = plantDatabase.IDToPlantDataDict[chosenPlantsID[i]];

                if (plantDatabase.IDToPlantDataDict.ContainsKey(chosenPlantsID[i]))
                {
                    plantChoosing.SetPlant(plant.plantData, plant.plantID);
                    plantChoosing.SetupPlantUI();
                }
            }
            else
            {
                seedSlots[i].SetActive(false);
            }
        }
    }

    public bool CheckPlantsCount()
    {
        return chosenPlantsID.Count < seedSlots.Count;
    }
}
