using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (other.GetComponent<Attacker>())
        {
            FindObjectOfType<Lives>().DecreaseLives();
        }
        Destroy(otherObject);
    }
}
