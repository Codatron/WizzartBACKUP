using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaintHit : MonoBehaviour, IGetKnockedBack
{
    public SpriteRenderer enemySpriteRenderer;
    public int hitPointsMax;

    public Rigidbody2D enemyRb;
    private int enemyHit;
    public bool isDead;

    private AudioSource audioSource;
    public AudioClip clipHit;

    void Start()
    {
        enemyHit = 0;
        isDead = false;
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(clipHit);
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
    }
}
