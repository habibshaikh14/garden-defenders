using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        Attacker attacker = other.GetComponent<Attacker>();
        if(attacker)
        {
            // Do some animation
        }
    }
}
