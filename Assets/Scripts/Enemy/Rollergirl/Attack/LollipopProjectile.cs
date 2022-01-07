using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    Player, 
    Ally,
}

public class LollipopProjectile: MonoBehaviour
{ 
    public Target targetName;
    public float speed;
    public float rotationSpeed;
    
    private Transform player;
    private Vector2 target;
    public float lifeSpan;

    private void Start()
    {
        //Makes lollipop find the position of the Player
        GameObject p = GameObject.FindGameObjectWithTag(targetName.ToString());


        if (p ==null)
        {
            Destroy(gameObject);
            
        }

        else
        {
            player = p.transform;
            target = player.position;
            Destroy(gameObject, lifeSpan);
        }
    
    }

    private void Update()
    {
        //Makes lollipop move towards players position and destroys lollipop when it hits Players position
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.Rotate(Vector3.forward * rotationSpeed);

        if (transform.position.x == target.x && transform.position.y == target.y) // if lollipop hangs it could be this line
        {
            DestroyLollipop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroys lollipop when it hits player
        if (other.CompareTag("Player"))
        {
            DestroyLollipop();
        }
    }

    void DestroyLollipop()
    {
        Destroy(gameObject);
    }
}