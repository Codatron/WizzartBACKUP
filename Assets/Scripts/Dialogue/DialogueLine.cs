using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;

        [Header("Text Options")]
        [SerializeField, TextArea] private string input;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private Coroutine lineAppear;


        private void Awake()
        {
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }
        private void Start()
        {
            ResetLine();           
            lineAppear=  StartCoroutine(WriteText(input, textHolder, delay, sound, delayBetweenLines));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textHolder.text != input)
                {
                    if (lineAppear != null)
                    {
                        StopCoroutine(lineAppear);
                    }

                    textHolder.text = input;
                }
                else
                    finished = true;
            }
        }

        private void Line()
        {
            if (textHolder.text != input)
            {
                if (lineAppear != null)
                {
                    StopCoroutine(lineAppear);
                }

                textHolder.text = input;
            }
            else
                finished = true;
        }

    

        private void ResetLine()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";
            finished = false;
        }
    }
}
