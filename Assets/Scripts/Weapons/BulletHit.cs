using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //public Rigidbody2D bulletRb;
    //public Sprite enemySpriteDead;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("EnemyLips") || other.gameObject.CompareTag("EnemyLollipopGirlPink"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
    // TODO add collisions/triggers for the different enemies and include HP taken by them 24/11
