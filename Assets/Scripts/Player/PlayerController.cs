using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
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
        //TODO make time stop when in dialogue 

        if(npc != null)
        
            return npc.DialogueActive();
        else
            return false;
     
    }
    private void OnTriggerStay2D(Collider2D collision) // OM COLLISION
    {
        if (collision.gameObject.tag == ("Cage1") || collision.gameObject.tag == ("Cage2") || collision.gameObject.tag == ("Cage3"))
        {
            npc = collision.gameObject.GetComponent<NPCController>();

            Debug.Log("Hi!");

            if (Input.GetKey(KeyCode.E)) //HAR PRATAR DOM 
            npc.ActivateDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }
}
