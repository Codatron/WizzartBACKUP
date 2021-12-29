using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using DG.Tweening;

public class PickUpBomb : MonoBehaviour
{
    public GameObject bombFactory;
    public GameObject dropBombPos;
    public GameObject factory_1;
    public GameObject boom;
    public Sprite factory_2;
    public Sprite factory_3;
    public GameObject clone;
    public CameraShake cameraShake;
    public SpawnBomb refSpawnBomb;
    public GameObject boomPlace;
    public Transform camera2;


    private BoolKeeper refBoolKeeper;
    public int bombCounter = 0;

    Vector3 cameraOrgPos;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();
    }

    //public void ChangeFactory()
    //{
    //    if (bombCounter == 1)
    //    {
    //        PlayExplosion();


    //        factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;
    //    }

    //    if (bombCounter == 2)
    //    {
    //        PlayExplosion();
    //        factory_1.GetComponent<SpriteRenderer>().sprite = factory_3;//ANDRA HAR
    //    }

    //    if (bombCounter == 3)
    //    {
    //        PlayExplosion();
    //        factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;//ANDRA HAR
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BombNoHands"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Factory") && GetComponent<SpriteRenderer>().enabled == true) //TO DO BOX COLLIDER FoLJER INTE MED NAR MAN BYTER
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = true;
            clone = Instantiate(bombFactory, dropBombPos.transform.position, Quaternion.identity);

            bombExposition();

            refBoolKeeper.dontShoot = false;

            bombCounter++;
            refSpawnBomb.bombSpawnCounter = 0;

            Debug.Log(refSpawnBomb.bombSpawnCounter);
        }
    }

    private void bombExposition()
    {
        Destroy(clone, 2);

        Invoke(nameof(PlayExplosion), 2);
    }

    private void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    PlayExplosion();
        //}
    }

    public void PlayExplosion()
    {
        Time.timeScale = 0;
        cameraOrgPos = camera2.transform.position;
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Factory").transform.position;
        targetPos.z = cameraOrgPos.z;
        camera2.transform.DOMove(targetPos, 1).SetUpdate(true);//1 sek aka dit

        StartCoroutine("Explosion");
        camera2.transform.DOMove(cameraOrgPos, 1).SetDelay(2).SetUpdate(true).OnComplete(Reset);//1 sek tillbaka 2sek som allt tog
    }
   public IEnumerator Explosion()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameObject boomClone = Instantiate(boom, boomPlace.transform.position, Quaternion.identity);
        StartCoroutine(cameraShake.Shake(.25f, .8f));
        Destroy(boomClone, 0.8f);

        if (bombCounter==1)
        {
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;
        }

        if (bombCounter==2)
        {
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_3;
        }
        //if (bombCounter == 3)
        //{
        //    factory_1.GetComponent<SpriteRenderer>().sprite = factory_4;
        //}
    }

    private void Reset()
    {
        Time.timeScale = 1;
    }

 
}

