using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject resourses;

    private void Start()
    {
        resourses = GameObject.Find("Resourse");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        resourses.SetActive(false);
        Time.timeScale = 0f;
        GameIsPause = true;  

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        resourses.SetActive(true);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
