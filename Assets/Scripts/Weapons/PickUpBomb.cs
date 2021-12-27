using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

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


    private BoolKeeper refBoolKeeper;
    public int bombCounter = 0;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();
    }

    public void ChangeFactory()
    {
        if (bombCounter == 1)
        {          
            Boom();

           
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;
        }

        if (bombCounter == 2)
        {
            Boom();
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_3;//ANDRA HAR
        }

        if (bombCounter == 3)
        { 
            Boom();
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;//ANDRA HAR
        }
    }

    private void Boom()
    {
        GameObject boomClone = Instantiate(boom, boomPlace.transform.position, Quaternion.identity);
        Destroy(boomClone, 0.8f);

        //CameraShaker.Instance.ShakeOnce(6f,6f,.1f,1f);

        StartCoroutine(cameraShake.Shake(.25f, .8f)); //LAGG TILL SMOOTHING

        //Vector3.Lerp (vector3pos, vector3pos you want, smoothingfloat)


    }

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
        Destroy(clone,2);
       
        Invoke(nameof(ChangeFactory), 2);
    }

    //TODO NY SPRITE FOR BOMB MAN INSTANSIATAR VID FABRIKEN
}

