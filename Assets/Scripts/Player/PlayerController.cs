using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DialogueSystem;

    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public Transform firePoint;
        public GameObject playerBullets;
        public ParticleSystem dust;
        public AudioSource playerRunning;
        public SpriteRenderer playerSpriteRenderer;

        private NPCController npc;
        private Rigidbody2D player;
        private float xAxis;
        private float yAxis;

        CageHealth cageHealth;
        DialogueBaseClass dialogueBaseClass;

        private void Start()
        {
            player = GetComponent<Rigidbody2D>();
            cageHealth = FindObjectOfType<CageHealth>();
            
        }
        private void FixedUpdate()
        {
            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");
            player.velocity = (new Vector2(xAxis, yAxis).normalized * speed);

            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRunning.mute = false;
                CreateDust();
            }

            else
            {
                playerRunning.mute = true;
            }
        }

        private void RotateAnimation()
        {
            if (Input.GetAxis("Horizontal") > 0.01f)
            {
                playerSpriteRenderer.flipX = false;
            }

            else if (Input.GetAxis("Horizontal") < -0.01f)
            {
                playerSpriteRenderer.flipX = true;
            }
        }
        void CreateDust()
        {
            dust.Play();
        }
        private bool inDialogue()
        {
            if (npc != null)

                return npc.DialogueActive();
            else
                return false;
        }

        public void StartDialog(GameObject cage)
        {
            Debug.Log("Hej");
            npc = cage.GetComponent<NPCController>();

           
            npc.ActivateDialogue();

        //    do
        //    {
        //        yield return new WaitForEndOfFrame();

        //    } while (dialogueBaseClass.finished == false);

        //    StopDialog();
        //}

        //public void StopDialog()
        //{

        //    npc = null;
        } 
    }

