using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantChoosing : MonoBehaviour
{
    #region Setup

    [SerializeField] PlantBase_SO choosenPlant;
    [SerializeField] Image displayImage;
    [SerializeField] TextMeshProUGUI sunCostTMP;
    [SerializeField] GameObject seedCover;

    #endregion

    private void Start()
    {
        SetupPlantUI();
    }

    void SetupPlantUI()
    {
        GetComponent<Button>().onClick.AddListener(SelectPlant);

        displayImage.sprite = choosenPlant.PlantDisplaySprite;
        displayImage.enabled = true;

        sunCostTMP.text = choosenPlant.SunCost.ToString();
    }

    void SelectPlant()
    {
        GameManager.instance.GetChosenPlant(choosenPlant, seedCover);
        seedCover.SetActive(true);
    }
}
