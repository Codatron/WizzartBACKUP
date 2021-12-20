using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void ExitLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
