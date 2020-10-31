﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] bool spawn;
    [SerializeField] Attacker attacker;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 4f ;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(attacker, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
