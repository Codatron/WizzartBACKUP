using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAteljéToggle : MonoBehaviour
{
    public GameObject currentDialogue;
    public GameObject nextDialogue;

    void Update()
    {
        if (!currentDialogue.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nextDialogue.SetActive(true);
            }
        }    
    }
}
