using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] GameObject levelLostCanvas;
    [SerializeField] float timeDelayForNextLevel = 3f;
    private int numberOfAttackers = 0;
    private bool levelFinished = false;

    private void Start() {
        if (levelCompleteCanvas)
        {
            levelCompleteCanvas.SetActive(false);
        }
        if (levelLostCanvas)
        {
            levelLostCanvas.SetActive(false);
        }
    }

    public void EnemySpawned()
    {
        numberOfAttackers++;
    }

    public void EnemyKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelFinished)
        {
            StartCoroutine(HandleLevelWin());
        }
    }

    private IEnumerator HandleLevelWin()
    {
        levelCompleteCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeDelayForNextLevel);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelLost()
    {
        levelLostCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelFinished()
    {
        levelFinished = true;
        StopSpawnners();
    }

    private void StopSpawnners()
    {
        Spawnner[] spawnners = FindObjectsOfType<Spawnner>();
        foreach (Spawnner spawnner in spawnners)
        {
            spawnner.StopSpawning();
        }
    }
}
