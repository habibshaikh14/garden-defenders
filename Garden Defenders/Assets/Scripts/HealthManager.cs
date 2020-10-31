using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject deathVFX;

    public float GetHealth()
    {
        return health;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(deathVFX)
        {
            GameObject explosionVFX = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
            Destroy(explosionVFX, 1f);
        }
    }
}
