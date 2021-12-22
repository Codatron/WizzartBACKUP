using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    public GameObject dialogBox;
    public static bool dialogActive;

    private void Start()
    {
        dialogActive = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        dialogBox.SetActive(true);
        dialogActive = true;
    }
    private void Update()
    {
        if(dialogActive)
        {
            Time.timeScale = 0f;
        }
    }
    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }
}
