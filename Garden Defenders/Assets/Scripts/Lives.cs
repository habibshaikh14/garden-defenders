using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 20;
    Text livesText;

    private void Start() {
        livesText = GetComponent<Text>();
        UpdateLives();
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
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
        }
    }
}
