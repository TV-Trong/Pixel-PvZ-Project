using UnityEngine;

public class PlantSpawning : MonoBehaviour
{
    #region Setup

    [SerializeField] GridManager gridManager;

    [SerializeField] GameObject plantHolder;

    GameManager gameManager;

    #endregion

    private void Start()
    {
        gameManager = GameManager.instance;
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

                newPlant.transform.SetParent(plantHolder.transform);

                gridManager.UpdateGrid(mousePosition, true);

                gameManager.PlantingSuccess();
            }

            if (Input.GetMouseButtonDown(1))
            {
                gameManager.RemoveHoldingPlant();
            }
        }
    }
}
