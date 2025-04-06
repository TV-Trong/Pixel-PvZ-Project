using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedSlot : MonoBehaviour
{
    #region Setup

    [SerializeField] PlantBase_SO choosenPlant;
    [SerializeField] Image displayImage;
    [SerializeField] TextMeshProUGUI sunCostTMP;
    [SerializeField] GameObject seedCover;

    int plantID;

    PlantChoosingMenu plantChoosingMenu;

    #endregion

    private void Awake()
    {
        plantChoosingMenu = FindObjectOfType<PlantChoosingMenu>();
    }

    public void SetupPlantUI()
    {
        GetComponent<Button>().onClick.AddListener(OnClickSeedSlot);

        displayImage.sprite = choosenPlant.PlantDisplaySprite;
        displayImage.enabled = true;

        sunCostTMP.text = choosenPlant.SunCost.ToString();
    }

    void OnClickSeedSlot()
    {
        if (GameManager.instance.gameState == GameState.PlantChoosing)
        {
            RemoveChosenPlant();
        }
        else if (GameManager.instance.gameState == GameState.InGame)
        {
            GameManager.instance.GetHoldingPlant(choosenPlant, seedCover);
            seedCover.SetActive(true);
        }
    }

    public void SetPlant(PlantBase_SO plant, int ID)
    {
        choosenPlant = plant;
        plantID = ID;
    }

    public void RemoveChosenPlant()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();

        displayImage.sprite = null;
        displayImage.enabled = false;

        sunCostTMP.text = string.Empty;

        choosenPlant = null;

        plantChoosingMenu.RemoveChosenPlant(plantID);

        gameObject.SetActive(false);
    }
}
