using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantChoosing : MonoBehaviour
{
    [SerializeField] Plant choosenPlant;

    [SerializeField] Image displayImage;
    [SerializeField] TextMeshProUGUI sunCostTMP;

    private void Awake()
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
        GameManager.instance.GetChosenPlant(choosenPlant);
    }
}
