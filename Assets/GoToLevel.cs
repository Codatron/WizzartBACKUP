using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    PlayerHit playerHit;

    private void Start()
    {
        playerHit = FindObjectOfType<PlayerHit>();
    }

    private void Update()
    {
        theEnd();
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
            //playerHit.playerHealthCurrent = 50;


        }
        
    }

    IEnumerator theEnd()
    {
        yield return new WaitForSeconds(6);

        SceneManager.LoadScene(sceneBuildIndex: 1); 
        MusicSound.PlayMenuMusic();
    }

 
}
