using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpBomb : MonoBehaviour
{
    public GameObject bombFactory;
    public GameObject dropBombPos;
    
    private BoolKeeper refBoolKeeper;
    private int bombCounter = 0;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();
    }

    private void Update()
    {
        if (bombCounter == 2)
        {
            //TO DO andra factyre sprite och explosition?
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
            GameObject clone = Instantiate(bombFactory, dropBombPos.transform.position, Quaternion.identity);
            refBoolKeeper.dontShoot = false;
            bombCounter++;
        }
    }
}
