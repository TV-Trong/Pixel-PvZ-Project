using UnityEngine;

public class Planting : MonoBehaviour
{
    [SerializeField] GridManager gridManager;

    GameManager gameManager;

    GameObject plantHolder;//Remove when done

    private void Start()
    {
        gameManager = GameManager.instance;

        plantHolder = GameObject.FindWithTag("PlantHolder");
    }

    private void Update()
    {
        if (gameManager.IsHoldingPlant())
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject plantPrefab = gameManager.GetPlantPrefab();

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (plantPrefab == null || gridManager.IsGridOccupied(mousePosition) || !gameManager.HaveEnoughSun())
                    return;

                GameObject newPlant = Instantiate(plantPrefab, gridManager.GetWorldPosition(mousePosition), Quaternion.identity);// Change to pooling later

                newPlant.layer = LayerMask.NameToLayer("Ignore Raycast");

                newPlant.transform.SetParent(plantHolder.transform);//Remove when done

                gridManager.UpdateGrid(mousePosition, true);

                gameManager.PlantingSuccess();
            }

            if (Input.GetMouseButtonDown(1))
            {
                gameManager.RemoveChosenPlant();
            }
        }
    }
}
