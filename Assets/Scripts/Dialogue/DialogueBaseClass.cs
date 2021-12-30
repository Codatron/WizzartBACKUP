using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace DialogueSystem
   
{

public class DialogueBaseClass : MonoBehaviour
    {
       public bool finished { get; protected set; }
       protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder,  float delay, AudioClip sound, float delayBetweenLines)
       {
            for (int i = 0; i < input.Length; i++)
           {
                textHolder.text += input[i];
                DialogueSound.instance.PlayDialogueSound(sound);
                yield return new WaitForSecondsRealtime(delay);
           }
            yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));

            finished = true;
       }
    }
}