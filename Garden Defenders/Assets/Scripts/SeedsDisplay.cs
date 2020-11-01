using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedsDisplay : MonoBehaviour
{
    [SerializeField] int seeds = 100;
    Text seedsText;

    private void Start() {
        seedsText = GetComponent<Text>();
        UpdateSeeds();
    }

    private void UpdateSeeds()
    {
        seedsText.text = seeds.ToString();
    }

    public bool HaveEnoughSeeds(int cost)
    {
        return seeds >= cost;
    }

    public void AddSeeds(int amount)
    {
        seeds += amount;
        UpdateSeeds();
    }

    public void SpendSeeds(int amount)
    {
        if (seeds >= amount)
        {
            seeds -= amount;
            UpdateSeeds();
        }
    }
}
