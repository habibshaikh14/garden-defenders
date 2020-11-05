using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer time value in seconds.")]
    [SerializeField] float levelTime = 10f;

    private bool levelFinished = false;
    
    void Update()
    {
        if (!levelFinished)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
            levelFinished = (Time.timeSinceLevelLoad >= levelTime);
            if (levelFinished)
            {
                FindObjectOfType<LevelController>().LevelFinished();
            }
        }
        
    }
}
