using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSelector : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Defender defender;

    private void Start() {
        LabelButtonsWithCost();
    }

    private void LabelButtonsWithCost()
    {
        Text cost = GetComponentInChildren<Text>();
        if (cost)
        {
            cost.text = defender.GetSpawnCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var defenderButtons = FindObjectsOfType<DefenderSelector>();
        foreach (var defenderButton in defenderButtons)
        {
            defenderButton.GetComponent<SpriteRenderer>().color = new Color32(51, 51, 51, 255);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawnner>().SetDefender(defender);
    }
}
