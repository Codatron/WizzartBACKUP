using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopPink : MonoBehaviour
{
    Transform ally;
    Vector2 targetAlly;
    public float speed;
    float rotationSpeed = 15.0f;

    private void Start()
    {
        //Makes lollipop find the position of the Player
        ally = GameObject.FindGameObjectWithTag("Ally").transform;
  
        targetAlly = new Vector2(ally.position.x, ally.position.y);
       
    }

    private void Update()
    {
        //Makes lollipop move towards players position and destroys lollipop when it hits Players position
        transform.position = Vector2.MoveTowards(transform.position, targetAlly, speed * Time.deltaTime);

        transform.Rotate(Vector3.forward * rotationSpeed);
        
        if (transform.position.x == targetAlly.x && transform.position.y == targetAlly.y)
        {
            DestroyLollipop();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroys lollipop when it hits player
        if (other.CompareTag("Ally"))
        {
            DestroyLollipop();
        }
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
