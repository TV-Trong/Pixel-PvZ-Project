using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting : MonoBehaviour
{
    [SerializeField] GridManager gridManager;

    GameManager gameManager;

    GameObject plantHolder;

    private void Awake()
    {
        gameManager = GameManager.instance;

        plantHolder = GameObject.FindWithTag("PlantHolder");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.GetPlantPrefab() == null)
                return;

            Vector3 plantPosition = gridManager.GetWorldPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)); // Change to pooling later

            GameObject newPlant = Instantiate(gameManager.GetPlantPrefab(), plantPosition, Quaternion.identity);

            newPlant.transform.SetParent(plantHolder.transform);

            gameManager.RemoveChosenPlant();
        }
    }
}
