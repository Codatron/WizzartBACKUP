using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CageHealth : MonoBehaviour
{
    public int health;
    public Sprite cage_1;
    public Sprite cage_2;
    public Sprite cage_3;
    public Sprite cage_4;
    public Sprite cage_5;
    public Transform camera2;
    public GameObject moveCameraTo;
 
    public MoveCamera moveCamera;

    Vector3 cameraOrgPos;

    bool OnlyOnce = true;
    public bool pickUpBomb= false;
    public bool startDialog = false;

    public int spriteRend = 0;
    //public AudioClip brookenGlas;
    //public AudioSource speaker;
    public CircleCollider2D circleCol;

    PlayerController playerController;
    public GameObject startDialogCage;

    PlayerHit playerHit;


    void Start()
    {        
        health = 30;
        playerController = FindObjectOfType<PlayerController>();
        playerHit = FindObjectOfType<PlayerHit>();

    }

    void Update()
    {
        HealthCage();

        if (spriteRend == 1)
        {
            GetComponent<SpriteRenderer>().sprite = cage_4;
        }

        if (spriteRend == 2)
        {
            GetComponent<SpriteRenderer>().sprite = cage_5;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ProjectilePlayer"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }

    public void HealthCage()
    {                     
        if (health < 20 )

        {                      
            GetComponent<SpriteRenderer>().sprite = cage_2;
            //speaker.PlayOneShot(brookenGlas); //FUNKAR EJ BRA
        }
        if (health < 10)
        {            
            
            GetComponent<SpriteRenderer>().sprite = cage_3;
            
        }

        if (health <= 0 && OnlyOnce) 
        {
            
            OnlyOnce = false;            
            moveCamera.CameraMoveTo(moveCameraTo);
            playerController.StartDialog(startDialogCage);

            pickUpBomb = true;      
            Destroy(circleCol);
            startDialog = true;
            playerHit.playerHealthCurrent = 20;
          
        }
    }
}
