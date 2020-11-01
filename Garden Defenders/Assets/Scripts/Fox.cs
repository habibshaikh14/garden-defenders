using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if(otherObject.GetComponent<Wall>())
            {
                MakeFoxJump();
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }
    }

    private void MakeFoxJump()
    {
        GetComponent<Animator>().SetTrigger("JumpTrigger");
    }
}
