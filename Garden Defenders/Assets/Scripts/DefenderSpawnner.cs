using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawnner : MonoBehaviour
{
    // State variables
    private Defender defender;
    private GameObject defenderParent;
    private const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start() {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void SetDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void PlaceDefender(Vector2 gridPos)
    {
        SeedsDisplay seedDisplay = FindObjectOfType<SeedsDisplay>();
        int defenderCost = defender.GetSpawnCost();
        if (seedDisplay.HaveEnoughSeeds(defenderCost))
        {
            SpawnDefender(gridPos);
            seedDisplay.SpendSeeds(defenderCost);
        }
    }
    private void OnMouseDown()
    {
        PlaceDefender(GetSquareClicked());
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
        Defender defender = Instantiate(this.defender, worldPos, Quaternion.identity) as Defender;
        defender.transform.parent = defenderParent.transform;
    }
}
