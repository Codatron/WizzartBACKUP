using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        //Checks if there are volume sliders value saved from before and loads them. If there is no saved value, sets volume to 100%
        if(!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        //Loads the volume sliders value from last session
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    private void Save()
    {
        //Saves the value of the volume slider between different play sessions
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
