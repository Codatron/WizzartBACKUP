using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("theEnd");      
    }

   private IEnumerator theEnd()
    {
        yield return new WaitForSecondsRealtime(10);

        SceneManager.LoadScene(sceneBuildIndex: 0);
        MusicSound.PlayMenuMusic();
    }
}
