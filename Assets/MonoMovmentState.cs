using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoMovmentState : MonoBehaviour
{
    public Transform[] movePoints;
    public float speed;
    private int amount;
    private int offSet;
    private Transform currentTarget;
    private float timer = 0f;

    void Start()
    {
        randoming();
    }

    void Update()
    {
        Movement();
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            randoming();
            timer = 0f;
        }
    }

    void randoming()
    {   
        offSet = Random.Range(-2,2);
        amount = Random.Range(0, movePoints.Length);
        currentTarget = movePoints[amount];
    }

    void Movement()

    {       
        Vector3 clonePosition = new Vector3(currentTarget.position.x + offSet, currentTarget.position.y+ offSet);
        transform.position = Vector3.MoveTowards(transform.position, clonePosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MonoClone") || other.CompareTag("Mono"))

        {
            Movement();
        }
        
    }

}

  

