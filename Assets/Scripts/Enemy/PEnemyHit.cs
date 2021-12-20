using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEnemyHit : MonoBehaviour, IGetKnockedBack
{
    public SpriteRenderer enemySpriteRenderer;
    public int hitPointsMax;

    private Rigidbody2D enemyRb;
    private int enemyHit;
    public bool isDead = false;

    void Start()
    {
        enemyHit = 0;
        
    }

    void Update()
    {

    }

    IEnumerator EnemyTakeDamageColour()
    {
        enemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        enemySpriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.05f);
        enemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        enemySpriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ProjectilePlayer"))
        {
            enemyHit++;
            StartCoroutine(EnemyTakeDamageColour());
            // play audio
        }

        if (enemyHit >= hitPointsMax)
        {
            Destroy(gameObject);
        }
    }

    public void KnockMeBack(float magnitude, Vector2 direction)
    {
        direction = direction.normalized;
        enemyRb.AddForce(magnitude * direction);
        Debug.Log(direction);
    }
}
