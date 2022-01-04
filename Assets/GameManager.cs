using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Quick and dirty fix for playing ONE instance of a sfx.
    /// </summary>
    /// <param name="clip"> AudioClip to play </param>
    /// <param name="timeUntilDestroy"> Removes AudioSource after this time </param>
    /// 
    public static void PlaySFXDirty(AudioClip clip, float timeUntilDestroy)
    {
        AudioSource s = new GameObject().AddComponent<AudioSource>();
        s.PlayOneShot(clip);
        Destroy(s.gameObject, timeUntilDestroy);
    }
}
