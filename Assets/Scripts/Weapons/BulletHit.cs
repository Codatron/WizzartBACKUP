using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    int damageMono = 0;

    private float lifeSpan = 0.5f;

    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("EnemyLips") || other.gameObject.CompareTag("EnemyLollipopGirlPink")|| other.gameObject.CompareTag("PaintEnemy") || other.gameObject.CompareTag("Environment") || other.gameObject.CompareTag("MonoClone"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Mono"))
        {
            damageMono = 3;
            MonoHealth mh = other.GetComponent<MonoHealth>();

            if (mh!= null)
            {
                other.GetComponent<MonoHealth>().TakeDamage(damageMono);
            }
            
            Destroy(gameObject);         
        }
    }
}
    // TODO add collisions/triggers for the different enemies and include HP taken by them 24/11
