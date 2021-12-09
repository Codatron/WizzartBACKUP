using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public Rigidbody2D RBBullets;
    public bool isEnemyDead = false;
    public Sprite enemySpriteDead;

    private SpriteRenderer enemySpriteRenderer;
    private EnemyFlip enemyFlipScript;
    private float speed = 10;
    
    void Start()
    {
        RBBullets.velocity = transform.right * speed;
        enemySpriteRenderer = GameObject.FindGameObjectWithTag("EnemyLollipopGirlBlue").GetComponent<SpriteRenderer>();
        enemyFlipScript = GameObject.FindGameObjectWithTag("EnemyLollipopGirlBlue").GetComponent<EnemyFlip>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("EnemyLips") || other.gameObject.CompareTag("EnemyLollipopGirlPink"))
        {

            //enemySpriteRenderer.sprite = enemyFlipScript.enemySpriteDead;
            isEnemyDead = true;

            //enemyFlipScript.DeadSprite();
            Destroy(other.gameObject, 1.25f);
            Destroy(gameObject);
        }

    }

    // TODO add collisions/triggers for the different enemies and include HP taken by them 24/11
}
