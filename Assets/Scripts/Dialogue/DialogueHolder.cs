using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogSeq;
        private void OnEnable()
        {
            dialogSeq = dialogueSequence();
            StartCoroutine(dialogSeq);
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogSeq);
            }
        }
        private IEnumerator dialogueSequence()
        {
            Time.timeScale = 0;
            //Deactivate();
            //yield return new WaitForSecondsRealtime(3);

            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
