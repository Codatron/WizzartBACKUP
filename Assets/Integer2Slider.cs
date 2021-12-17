using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Integer2Slider : MonoBehaviour
{
    Slider slider;
    public Integer2 int2Ref;

    void Start()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = int2Ref.integerB;
        slider.value = int2Ref.integerA;
    }
}
