using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public Rigidbody2D bulletRb;
    public Sprite enemySpriteDead;
    int damageMono = 0;
   // public Sprite[] sprites;

    //private void Start()
    //{
    //    GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("EnemyLips") || other.gameObject.CompareTag("EnemyLollipopGirlPink"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Mono"))
        {
            damageMono = 5;
            Destroy(gameObject);
            other.GetComponent<MonoHealth>().TakeDamage(damageMono);
        }
    }
}
    // TODO add collisions/triggers for the different enemies and include HP taken by them 24/11
