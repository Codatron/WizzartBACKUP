using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBombCage : MonoBehaviour
{
    public bool pickUpBomb = true;
    public CageHealth cageHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player") && pickUpBomb)
	    {

            cageHealth.spriteRend = 2;

            GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;

            pickUpBomb = true;

	    }               
    }
}
