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
    public Transform camera2;
    public CameraShake cameraShake;
    public GameObject Crash;
    public GameObject CrashPlace;
    Vector3 cameraOrgPos;

    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthCage();
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
        if (health < 70 )

        {                      
            GetComponent<SpriteRenderer>().sprite = cage_2;
        }
        if (health < 30)
        {            
            
            GetComponent<SpriteRenderer>().sprite = cage_3;
            
        }

        if (health < 0 && GetComponent<SpriteRenderer>().sprite == cage_3)
        {            
            
            GetComponent<SpriteRenderer>().sprite = cage_4;
           // StartCoroutine("Explosion");
            GlasBreak();
        }
    }

    public void GlasBreak()
    {
        Time.timeScale = 0;
        cameraOrgPos = camera2.transform.position;
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Cage1").transform.position;
        targetPos.z = cameraOrgPos.z;
        camera2.transform.DOMove(targetPos, 2).SetUpdate(true);//1 sek aka dit


        StartCoroutine("Explosion");

        camera2.transform.DOMove(cameraOrgPos, 2).SetDelay(2).SetUpdate(true).OnComplete(Reset);//1 sek tillbaka 2sek som allt tog
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
        Destroy(boomClone);
    }


    //TODO lägg in krossa glas ljud istallet for pang. 
    //TODO flytta kamera bara sista gången.
}
