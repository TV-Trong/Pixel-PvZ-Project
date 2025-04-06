using System.Collections.Generic;
using UnityEngine;

public class SeedSlotManager : MonoBehaviour
{
    #region Setup

    [SerializeField] PlantDatabase plantDatabase;
    [SerializeField] List<GameObject> seedSlots;

    public List<int> chosenPlantsID = new List<int>();

    #endregion

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
