using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSound : MonoBehaviour
{

    [SerializeField]
    private AudioClip menuMusic;

    [SerializeField]
    private AudioClip levelMusic;

    [SerializeField]
    private AudioSource source;
    private static MusicSound instance = null;

    
    public static MusicSound Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this) //!= this means not in the scen where it was created
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject); //dont destrou objekt when new scen are loaded
    }

    private void Start()
    {
        PlayMenuMusic();
    }

    static public void PlayMenuMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    static public void PlayGameMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.levelMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
}
