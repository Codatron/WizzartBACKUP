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
        SceneManager.LoadScene(2);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        MusicSound.PlayMenuMusic();
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
