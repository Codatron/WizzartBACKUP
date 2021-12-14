using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTLolli : MonoBehaviour
{
    public GameObject targetGameObj;
    public float speed;
    Vector2 target;

    private void Start()
    {
        //Makes lollipop find the position of the Player
        FindTarget(targetGameObj);
    }

    private void Update()
    {
        //Makes lollipop move towards players position and destroys lollipop when it hits Players position
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
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

    void FindTarget(GameObject targetToFind)
    {
        target = new Vector2(targetToFind.transform.position.x, targetToFind.transform.position.y);
    }
}
