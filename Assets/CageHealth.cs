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
    public CameraShake cameraShake;
    public GameObject Crash;
    public GameObject CrashPlace;
    //GameObject cage1;

    //public MoveCamera moveCamera;

    Vector3 cameraOrgPos;

    bool OnlyOnce = true;
    bool pickUpBomb= false;

    int spriteRend = 0;
    //public AudioClip brookenGlas;
    //public AudioSource speaker;

   
    void Start()
    {
        
        health = 100;
       // cage1 = GameObject.FindGameObjectWithTag("Cage1");
    }

    // Update is called once per frame
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

        if (health <= 0 && OnlyOnce|| Input.GetMouseButton(1)) //HAR DET AR FEL. behover jag gore nya obcjet?
        {
            
            OnlyOnce = false;            
            MoveCamera();
            //moveCamera.CameraMoveTo(cage1);                     
            pickUpBomb = true;
        }
    }

    public void MoveCamera()
    {

        Time.timeScale = 0;
        cameraOrgPos = camera2.transform.position;
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Cage1").transform.position;
        targetPos.z = cameraOrgPos.z;
        camera2.transform.DOMove(targetPos, 1).SetUpdate(true);

        StartCoroutine("Explosion");

        camera2.transform.DOMove(cameraOrgPos, 1).SetDelay(2).SetUpdate(true).OnComplete(Reset);

    }

    private void Reset()
    {

        Time.timeScale = 1;
    }
    public IEnumerator Explosion()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameObject boomClone = Instantiate(Crash, CrashPlace.transform.position, Quaternion.identity);
        StartCoroutine(cameraShake.Shake(.25f, .8f));

        spriteRend = 1;
        Destroy(boomClone, 0.5f);

    }


    //TODO lägg in krossa glas ljud istallet for pang. 
    //TODO flytta kamera bara sista gången.

    //TODO fixa scripet för flytta kamera + explosition
}
