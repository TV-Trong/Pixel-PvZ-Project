using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap tilemap;

    public Vector3Int GetGridPosition(Vector3 worldPosition)
    {
        return tilemap.WorldToCell(worldPosition);
    }

    public Vector3 GetWorldPosition(Vector3Int gridPosition)
    {
        return tilemap.GetCellCenterWorld(gridPosition);
    }
}
