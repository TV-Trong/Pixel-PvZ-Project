using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    #region Setup

    [SerializeField] Tilemap tilemap;
    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;

    Dictionary<Vector3Int, bool> occupiedGrid = new Dictionary<Vector3Int, bool>();

    #endregion

    private void Awake()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                occupiedGrid.Add(new Vector3Int(x, y, 0), false);
            }
        }
    }

    public Vector3Int GetGridPosition(Vector3 worldPosition)
    {
        return tilemap.WorldToCell(worldPosition);
    }

    public Vector3 GetWorldPosition(Vector3 worldPosition)
    {
        return tilemap.GetCellCenterWorld(GetGridPosition(worldPosition));
    }

    public void UpdateGrid(Vector3 worldPosition, bool isPlanted)
    {
        occupiedGrid[GetGridPosition(worldPosition)] = isPlanted;
    }

    public bool IsGridOccupied(Vector3 worldPosition)
    {
        Vector3Int gridPosition = GetGridPosition(worldPosition);

        if (!occupiedGrid.ContainsKey(gridPosition))
        {
            Debug.LogWarning("Invalid planting spot!");
            return true;
        }

        if (occupiedGrid[gridPosition])
        {
            Debug.LogWarning("Grid is occupied!");
        }

        return occupiedGrid[gridPosition];
    }
}
