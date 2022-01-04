using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBombCage : MonoBehaviour
{
    
    public CageHealth cageHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player") && cageHealth.pickUpBomb)//&& pickUpBomb )//&& pickUpBomb

        {

            cageHealth.spriteRend = 2;

            GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;

           cageHealth.pickUpBomb = false;

	    }               
    }
}
