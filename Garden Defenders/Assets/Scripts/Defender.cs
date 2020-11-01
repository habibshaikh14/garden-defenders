using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int spawnCost = 100;

    public int GetSpawnCost()
    {
        return spawnCost;
    }

    public void AddSeeds(int amount)
    {
        FindObjectOfType<SeedsDisplay>().AddSeeds(amount);
    }

    
}
