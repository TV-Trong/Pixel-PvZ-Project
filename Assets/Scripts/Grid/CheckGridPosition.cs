using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGridPosition : MonoBehaviour
{
    public GridManager gridManager;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Grid Position: " + gridManager.GetGridPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            Debug.Log("Plant Position: " + gridManager.GetWorldPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
}
