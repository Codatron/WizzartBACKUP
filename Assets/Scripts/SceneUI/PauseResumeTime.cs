using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeTime : MonoBehaviour
{
    public bool gameIsPaused;
    public GameObject dialogue;
    public void Update()
    {
        if (!dialogue.activeSelf)
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        if (dialogue.activeSelf)
        {
                Time.timeScale = 0f;
                gameIsPaused = true;
        }  
    }
}
