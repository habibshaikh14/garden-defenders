using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float speed;
    [SerializeField] int damage = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthManager healthManager = other.GetComponent<HealthManager>();
        Attacker attacker = other.GetComponent<Attacker>();
        if (healthManager && attacker)
        {
            healthManager.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
