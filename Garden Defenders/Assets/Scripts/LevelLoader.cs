using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Configuration variables
    [SerializeField] float timeToWait = 3f;
    // State Variables
    private int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex.Equals(0))
        {
            StartCoroutine(LoadStartMenuScene());
        }
    }

    private IEnumerator LoadStartMenuScene()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Scene");
    }

    public void LoadSettingsMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Settings Scene");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
