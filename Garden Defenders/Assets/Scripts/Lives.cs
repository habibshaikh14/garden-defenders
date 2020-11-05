using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    int lives = 15;
    Text livesText;

    private void Start() {
        SetLivesBasedOnDifficulty();
        livesText = GetComponent<Text>();
        UpdateLives();
    }

    private void SetLivesBasedOnDifficulty()
    {
        switch (PlayerPrefsController.GetDifficulty())
        {
            case 0: lives = 20;
                    break;
            case 1: lives = 15;
                    break;
            case 2: lives = 10;
                    break;
            default:    lives = 15;
                        break;
        }
    }

    private void UpdateLives()
    {
        livesText.text = lives.ToString();
    }

    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLives();
        }
        else
        {
            FindObjectOfType<LevelController>().LevelLost();
        }
    }
}
