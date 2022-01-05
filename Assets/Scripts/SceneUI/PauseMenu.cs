using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    
    void Start()
    {
        pauseMenuUI.SetActive(false);
        Resume();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Debug.Log("Resumed");
                Resume();
            }
            else
            {
                Debug.Log("Paused");
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    { 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void ExitLevel()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
   
    }


    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("BossScene");
    }
}
