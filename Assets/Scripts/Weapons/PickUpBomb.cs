using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpBomb : MonoBehaviour
{
    public GameObject bombFactory;
    public GameObject dropBombPos;
    public GameObject factory_1;
    public Sprite factory_2;
    public GameObject clone;
    public CameraShake cameraShake;



    private BoolKeeper refBoolKeeper;
    private int bombCounter = 0;

    public SpawnBomb refSpawnBomb;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();
    }

    private void Update()
    {
        
    }

    public void ChangeFactory()
    {
        if (bombCounter == 1)
        {
            Debug.Log("Hej");
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;

        }

        if (bombCounter == 2)
        {
            //TODO EXPOASITION
        }

        if (bombCounter == 3)
        {
            //TODO EXPOASITION
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BombNoHands"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;
           
            Destroy(other.gameObject);    
        }

        if (other.gameObject.CompareTag("Factory")) //TO DO FIX
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
}

