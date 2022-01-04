using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        
    }

   
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetCurrentHealth(int health)
    {
        slider.value = health;
    }
}