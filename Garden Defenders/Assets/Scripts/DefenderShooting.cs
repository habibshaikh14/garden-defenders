using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooting : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] GameObject shootPoint, weapon;
    private Spawnner myLaneSpawnner;
    private Animator animator;

    private void Start()
    {
        SetLaneSpawnner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    
    private void SetLaneSpawnner()
    {
        Spawnner[] spawnners = FindObjectsOfType<Spawnner>();
        foreach (Spawnner spawnner in spawnners)
        {
            if (AreValuesCloseEnough(transform.position.y, spawnner.transform.position.y))
            {
                myLaneSpawnner = spawnner;
            }
        }
    }

    private bool AreValuesCloseEnough(float value1, float value2)
    {
        return (Mathf.Abs(value1 - value2) <= Mathf.Epsilon);
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawnner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(weapon, shootPoint.transform.position, shootPoint.transform.rotation);
    }
}
