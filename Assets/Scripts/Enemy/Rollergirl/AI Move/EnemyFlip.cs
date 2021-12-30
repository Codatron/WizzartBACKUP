using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public Sprite enemySpriteFrontA;
    public Sprite enemySpriteFrontB;
    public Sprite enemySpriteBackA;
    public Sprite enemySpriteBackB;
    public SpriteRenderer enemySpriteRenderer;
    //public Transform firePoint;

    private Transform player;
    private Rigidbody2D rb;
    private EnemyPatrol enemyPatrolScript;
    private bool isOverY;
    private float timeToNextChange = 0.667f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        enemyPatrolScript = GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (!enemyPatrolScript.isOnPatrol)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            enemySpriteRenderer.flipX = player.position.x < transform.position.x;
            isOverY = player.position.y > transform.position.y;

            if (time > timeToNextChange)
            {
                if (!isOverY)
                {
                    if (enemySpriteRenderer.sprite == enemySpriteFrontB)
                    {
                        enemySpriteRenderer.sprite = enemySpriteFrontA;
                    }
                    else
                    {
                        enemySpriteRenderer.sprite = enemySpriteFrontB;
                    }

                    time = 0.0f;
                }
                else
                {
                    if (enemySpriteRenderer.sprite == enemySpriteBackB)
                    {
                        enemySpriteRenderer.sprite = enemySpriteBackA;
                    }
                    else
                    {
                        enemySpriteRenderer.sprite = enemySpriteBackB;
                    }

                    time = 0.0f;
                }

                time = 0.0f;
            }      
        }
        else
        {
            if (rb.velocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            if (rb.velocity.x <= 0.01f)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
        }
    }
}
        //enemySpriteRenderer.sprite = isOverY ? enemySpriteBackA : enemySpriteFrontA;