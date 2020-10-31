using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] GameObject gun;
    [SerializeField] GameObject cactusThorn;
    public void Fire() {
        Instantiate(cactusThorn, gun.transform.position, gun.transform.rotation);
    }
}
