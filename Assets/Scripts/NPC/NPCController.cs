using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]private GameObject dialogue;

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
        Time.timeScale = 0;
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}
