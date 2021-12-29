using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DialogueSystem
{

public class DialogueBaseClass : MonoBehaviour
    {
       public bool finished { get; protected set; }
        //Color textColor, Font textFont,
       protected IEnumerator WriteText(string input, Text textHolder,  float delay, AudioClip sound, float delayBetweenLines)
       {
            //textHolder.color = textColor;
            //textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
           {
                textHolder.text += input[i];
                //SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
           }
            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));

            finished = true;
       }
    }
}