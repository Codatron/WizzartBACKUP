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
    
    void Update()
    {
        RBBullets.velocity = transform.right * speed;
        //enemyFlipScript = GameObject.FindGameObjectWithTag("EnemyLollipopGirlBlue").GetComponent<EnemyFlip>();
        //enemySpriteRenderer = GameObject.FindGameObjectWithTag("EnemyLollipopGirlBlue").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("EnemyLips") || other.gameObject.CompareTag("EnemyLollipopGirlPink"))
        {
            //enemySpriteRenderer.sprite = enemyFlipScript.enemySpriteDead;
            isEnemyDead = true;
            Destroy(other.gameObject, 1.25f);

            Destroy(this.gameObject);
            //isEnemyDead = false;
        }

    }

    // TODO add collisions/triggers for the different enemies and include HP taken by them 24/11
}
