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
    private bool isOverY;
    private float timeToNextChange = 0.667f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
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
        //enemySpriteRenderer.sprite = isOverY ? enemySpriteBackA : enemySpriteFrontA;
    }
}