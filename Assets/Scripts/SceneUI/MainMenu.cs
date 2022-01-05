using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    float m_MySliderValue;


    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        

    }
    public void ExitLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
        MusicSound.PlayGameMusic();




    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
