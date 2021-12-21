using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<Vector2> patrolPoints;
    public float force;
    public float stopDistance;
    public float alertDistance;

    private Rigidbody2D rb;
    private Transform target;
    private float distanceToTarget;
    private int currentPatrolPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        

        if (distanceToTarget <= alertDistance)
        {
            patrolPoints.Clear();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        float distanceToPoint = (patrolPoints[currentPatrolPoint] - (Vector2)transform.position).magnitude;

        if (distanceToPoint <= stopDistance)
        {
            currentPatrolPoint = currentPatrolPoint + 1;

            if (currentPatrolPoint >= patrolPoints.Count)
            {
                currentPatrolPoint = 0;
            }
        }

        Vector2 direction = (patrolPoints[currentPatrolPoint] - (Vector2)transform.position).normalized;

        rb.velocity = new Vector2(direction.x, direction.y) * force;
    }
}
