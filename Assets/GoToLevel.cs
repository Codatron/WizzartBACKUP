using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Painting"))
        {
            
            SceneManager.LoadScene("Level");

            MusicSound.PlayGameMusic();
        }

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("BossScene");
            MusicSound.PlayBossMusic();
        }
        
    }

 
}
