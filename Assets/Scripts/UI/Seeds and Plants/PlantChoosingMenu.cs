using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantChoosingMenu : MonoBehaviour
{
    #region Setup

    [SerializeField] PlantDatabase plantDatabase;
    [SerializeField] SeedSlotManager seedManager;
    [SerializeField] Button startGameButton;
    [SerializeField] List<GameObject> seedSlots = new List<GameObject>();

    #endregion

    private void Awake()
    {
        var plantList = plantDatabase.plantDataList;

        for (int i = 0; i < plantList.Count; i++)
        {
            if (plantList[i].isUnlocked)
            {
                int plantID = plantList[i].plantID;
                var seedSlotButton = seedSlots[i].GetComponent<Button>();

                seedSlotButton.onClick.AddListener(() => ChoosePlant(plantID, seedSlotButton));
                seedSlots[i].SetActive(true);
                seedSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = plantList[i].plantData.SunCost.ToString();
                seedSlots[i].transform.GetChild(1).GetComponent<Image>().sprite = plantList[i].plantData.PlantDisplaySprite;
            }
        }

        startGameButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        GameManager.instance.gameState = GameState.InGame;
        gameObject.SetActive(false);
    }

    void ChoosePlant(int plantID, Button seedSlotButton)
    {
        if (!seedManager.CheckPlantsCount())
        {
            Debug.LogWarning("Chosen plants count exceeded the limit.");
            return;
        }

        seedManager.chosenPlantsID.Add(plantID);
        seedManager.UpdateChosenPlant();
        seedSlotButton.interactable = false;
        seedSlotButton.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void RemoveChosenPlant(int plantID)
    {
        seedManager.chosenPlantsID.Remove(plantID);
        seedSlots[plantID].GetComponent<Button>().interactable = true;
        seedSlots[plantID].transform.GetChild(2).gameObject.SetActive(false);
    }
}
