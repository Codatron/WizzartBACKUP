using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (!currentDialogue.activeSelf && !nextDialogue.activeSelf)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
            //BYT LÅT
        }
    }
}
