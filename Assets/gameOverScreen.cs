using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    public void Restart()
    {      
       SceneManager.LoadScene(sceneBuildIndex: 3);
       MusicSound.PlayBossMusic();  
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
