using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeTime : MonoBehaviour
{
    public bool gameIsPaused;
    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
