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
    private SinePatrol sinePatrolScript;
    private bool isOverY;
    private float timeToNextChange = 0.667f;
    private float time;
    private float sineLimitX;
    private float sineLimitY;
    //private EnemyPatrol enemyPatrolScript;

    //float sineLimitX = 7.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //enemyPatrolScript = GetComponent<EnemyPatrol>();
        sinePatrolScript = GetComponent<SinePatrol>();

        sineLimitX = sinePatrolScript.sineX.sineMag / 2f;
        sineLimitY = sinePatrolScript.sineY.sineMag / 2f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (!sinePatrolScript.isOnPatrol)
        {
            enemySpriteRenderer.flipX = player.position.x < transform.position.x;
            isOverY = player.position.y > transform.position.y;
            TimeToChangeSprite();
        }
        else
        {
            
                if (rb.velocity.x < sineLimitX)
                {
                    TimeToChangeSpriteFront();

                    if (sinePatrolScript.sineX.sine > sineLimitX)
                    {
                        enemySpriteRenderer.flipX = true;
                    }
                }
                if (rb.velocity.x >= -sineLimitX)
                {
                    TimeToChangeSpriteFront();

                    if (sinePatrolScript.sineX.sine < -sineLimitX)
                    {
                        enemySpriteRenderer.flipX = false;
                    }
                }

                //if (rb.velocity.y > -sineLimitY)
                //{
                //    enemySpriteRenderer.sprite = enemySpriteFrontA;

                //    time = 0.0f;
                //}
                //if (rb.velocity.y < sineLimitY)
                //{
                //    enemySpriteRenderer.sprite = enemySpriteBackA;

                //    time = 0.0f;
                //}

                //if (sinePatrolScript.sineX.sine > sineLimitX)
                //{
                //    enemySpriteRenderer.flipX = true;
                //    ChangeSpriteFront();
                //    //ChangeSpriteBack();
                //    time = 0.0f;
                //}

                //if (sinePatrolScript.sineX.sine < -sineLimitX)
                //{
                //    enemySpriteRenderer.flipX = false;
                //    ChangeSpriteFront();
                //    //ChangeSpriteBack();
                //    time = 0.0f;
                //}

                //if (sinePatrolScript.sineY.sine > sineLimitY)
                //{
                //    enemySpriteRenderer.sprite = enemySpriteFrontA;

                //    time = 0.0f;
                //}
                //if (sinePatrolScript.sineY.sine < -sineLimitY)
                //{
                //    enemySpriteRenderer.sprite = enemySpriteBackA;

                //    time = 0.0f;
                //}
            




            //if (transform.position.y < sinePatrolScript.sineUp.sine/*-0.5f*/)
            //{
            //    enemySpriteRenderer.sprite = enemySpriteFrontA;

            //    time = 0.0f;
            //}
            //if (transform.position.y >= -sinePatrolScript.sineUp.sine /*0.5f*/)
            //{
            //    enemySpriteRenderer.sprite = enemySpriteBackA;

            //    time = 0.0f;
            //}


            //if (rb.velocity.x < 0.0f)
            //{
            //    enemySpriteRenderer.flipX = true;

            //    TimeToChangeSprite();
            //}
            //if (rb.velocity.x >= 0.0f)
            //{
            //    enemySpriteRenderer.flipX = false;

            //    TimeToChangeSprite();
            //}

            //if (rb.velocity.y < -0.5f)
            //{
            //    enemySpriteRenderer.sprite = enemySpriteFrontA;

            //    time = 0.0f;
            //}
            //if (rb.velocity.y >= 0.5f)
            //{
            //    enemySpriteRenderer.sprite = enemySpriteBackA;

            //    time = 0.0f;
            //}
        }
    }
    private void ChangeSpriteBack()
    {
        if (enemySpriteRenderer.sprite == enemySpriteBackB)
        {
            enemySpriteRenderer.sprite = enemySpriteBackA;
        }
        else
        {
            enemySpriteRenderer.sprite = enemySpriteBackB;
        }
    }

    private void ChangeSpriteFront()
    {
        if (enemySpriteRenderer.sprite == enemySpriteFrontB)
        {
            enemySpriteRenderer.sprite = enemySpriteFrontA;
        }
        else
        {
            enemySpriteRenderer.sprite = enemySpriteFrontB;
        }
    }

    private void TimeToChangeSprite()
    {
        if (time > timeToNextChange)
        {
            if (!isOverY)
            {
                ChangeSpriteFront();

                time = 0.0f;
            }
            else
            {
                ChangeSpriteBack();

                time = 0.0f;
            }
        }
    }

    private void TimeToChangeSpriteFront()
    {
        if (time > timeToNextChange)
        {
            ChangeSpriteFront();

            time = 0.0f;
        }
    }
}



        //enemySpriteRenderer.sprite = isOverY ? enemySpriteBackA : enemySpriteFrontA;