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
    Transform player;
    Vector2 target;
    public float speed;
    float rotationSpeed = 15.0f;
    public Target targetName;

    private void Start()
    {
        //Makes lollipop find the position of the Player
        player = GameObject.FindGameObjectWithTag(targetName.ToString()).transform;
        target = player.position;
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