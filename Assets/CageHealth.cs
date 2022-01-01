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
    bool pickUpBomb= false;

    public int spriteRend = 0;
    //public AudioClip brookenGlas;
    //public AudioSource speaker;

   
    void Start()
    {
        
        health = 100;
       
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

        if (other.gameObject.CompareTag("Player") && pickUpBomb )
        {
            spriteRend = 2;
           
            GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;

            pickUpBomb = false;
        }
    }

    public void HealthCage()
    {                     
        if (health < 70 )

        {                      
            GetComponent<SpriteRenderer>().sprite = cage_2;
            //speaker.PlayOneShot(brookenGlas); //FUNKAR EJ BRA
        }
        if (health < 30)
        {            
            
            GetComponent<SpriteRenderer>().sprite = cage_3;
            
        }

        if (health <= 0 && OnlyOnce) 
        {
            
            OnlyOnce = false;            
            moveCamera.CameraMoveTo(moveCameraTo);
                                 
            pickUpBomb = true;
        }
    }

    //TODO lägg in krossa glas ljud istallet for pang. 

}
