using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetTest
{
    Player,
    Ally,
}

public class TESTLolliAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject target;

    public float speed = 10f;
    float rotationSpeed = 9.0f;

    public Vector3 movePosition;

    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("EnemyLollipopGirlBlue");
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        targetX = target.transform.position.x;
        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(player.transform.position.y, target.transform.position.y, (nextX - playerX) / dist);
        height = 2 * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        //transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.Rotate(Vector3.forward * rotationSpeed); 
        transform.position = movePosition;

        if (movePosition == target.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
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
