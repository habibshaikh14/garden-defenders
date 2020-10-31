using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawnner : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] GameObject defender;
    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        int newXPos = Mathf.RoundToInt(worldPos.x);
        int newYPos = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newXPos, newYPos);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Instantiate(defender, worldPos, Quaternion.identity);
    }
}
