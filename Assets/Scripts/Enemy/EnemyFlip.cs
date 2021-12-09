using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public Sprite enemySpriteFront;
    public Sprite enemySpriteBack;
    public Sprite enemySpriteDead;
    
    private SpriteRenderer enemySpriteRenderer;
    private Transform player;
    private BulletHit bulletHitScript;
    private bool isOverY;

    // Start is called before the first frame update
    void Start()
    {
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bulletHitScript = GameObject.FindGameObjectWithTag("ProjectilePlayer").GetComponent<BulletHit>();
    }

    // Update is called once per frame
    void Update()
    {
        enemySpriteRenderer.flipX = player.position.x < transform.position.x;
        isOverY = player.position.y > transform.position.y;
        enemySpriteRenderer.sprite = isOverY ? enemySpriteBack : enemySpriteFront;
        //enemySpriteRenderer.sprite = bulletHitScript.isEnemyDead == true && isOverY ? enemySpriteDead : enemySpriteBack;

        if (bulletHitScript.isEnemyDead == true)
        {
            enemySpriteRenderer.sprite = enemySpriteDead;
        }

    }
}