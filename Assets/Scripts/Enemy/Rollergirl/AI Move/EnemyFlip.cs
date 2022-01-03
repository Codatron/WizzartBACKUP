using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public SpriteRenderer enemySpriteRenderer;
    public Sprite enemySpriteFrontA;
    public Sprite enemySpriteFrontB;
    public Sprite enemySpriteBackA;
    public Sprite enemySpriteBackB;
    public bool isOnHorizontalPatrol;
    public bool isOnVerticalPatrol;

    private Transform player;
    private SinePatrol sinePatrolScript;
    private bool isOverY;
    private float timeToNextChange = 0.667f;
    private float time;
    private float sineLimitX;
    private float sineLimitY;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sinePatrolScript = GetComponent<SinePatrol>();

        sineLimitX = sinePatrolScript.sineX.sineMag / 1.2f;
        sineLimitY = sinePatrolScript.sineY.sineMag / 1.2f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (!sinePatrolScript.isOnPatrol)
        {
            enemySpriteRenderer.flipX = player.position.x < transform.position.x;
            isOverY = player.position.y > transform.position.y;
            CounterToChangeSpritePathfind();
        }
        else
        {
            if (isOnHorizontalPatrol)
            {
                CounterToChangeSpriteFront();
                SpriteFlipX();

                if (!sinePatrolScript.isPositiveSineX)
                {
                    enemySpriteRenderer.sprite = enemySpriteBackA;
                }
                else
                {
                    enemySpriteRenderer.sprite = enemySpriteFrontB;
                }

            }

            if (isOnVerticalPatrol)
            {
                SpriteFlipX();
                ChangeSpriteOnY();
            }
        }
    }

    private void ChangeSpriteOnY()
    {
        if (sinePatrolScript.sineY.sine > sineLimitY)
        {
            CounterToChangeSpriteFront();
        }
        if (sinePatrolScript.sineY.sine < -sineLimitY)
        {
            CounterToChangeSpriteBack();
        }
    }

    private void SpriteFlipX()
    {
        if (sinePatrolScript.sineX.sine > sineLimitX)
        {
            enemySpriteRenderer.flipX = true;
        }
        if (sinePatrolScript.sineX.sine < -sineLimitX)
        {
            enemySpriteRenderer.flipX = false;
        }
    }

    private void CounterToChangeSpriteFront()
    {
        if (time > timeToNextChange)
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
    }

    private void CounterToChangeSpriteBack()
    {
        if (time > timeToNextChange)
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
    }

    private void ChangeSpriteFrontPathfind()
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
    private void ChangeSpriteBackPathfind()
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

    private void CounterToChangeSpritePathfind()
    {
        if (time > timeToNextChange)
        {
            if (!isOverY)
            {
                ChangeSpriteFrontPathfind();

                time = 0.0f;
            }
            else
            {
                ChangeSpriteBackPathfind();

                time = 0.0f;
            }
        }
    }
}