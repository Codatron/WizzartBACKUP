using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIPathfind : MonoBehaviour
{
    public Rigidbody2D aiRb;
    public float speed;
    public float nextWaypointDistance = 3f;     // how close enemy needs to be to a waypoint before moving on to the next
    public float attackDistance;
    public bool isTargetWithinRange = false;

    private Transform target;                    // reference to target
    private Path path;                          // current path we are following
    private Seeker seeker;
    private int currentWaypoint = 0;            // stores current waypoint along path we are targeting
    private float distanceToTarget;
    private bool reachedEndOfPath = false;

    private EnemyPatrol refEnemyPatrol;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Generate path - (start point position, target position, function to invoke when calculation of path is complete) 
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        refEnemyPatrol = FindObjectOfType<EnemyPatrol>();
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(aiRb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        // make sure we have a path to follow
        if (path == null)
        {
            return;
        }

        // make sure there are more waypoints and that we haven't reached the end
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        // Move towards target when target acquired
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= attackDistance)
        {
            isTargetWithinRange = true;
            // move the enemy
            Vector2 direction = ((Vector2)target.position - aiRb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            aiRb.AddForce(force);
        }
        else
        {
            isTargetWithinRange = false;
        }
    }
}
