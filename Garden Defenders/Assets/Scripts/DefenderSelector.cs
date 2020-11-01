using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSelector : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Defender defender;

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
