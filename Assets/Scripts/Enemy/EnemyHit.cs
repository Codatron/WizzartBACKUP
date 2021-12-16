using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IGetKnockedBack
{
    public SpriteRenderer enemySpriteRenderer;
    public Sprite corpseSprite;
    public int hitPointsMax;

    private Rigidbody2D enemyRb;
    private int enemyHit;
    public bool isDead = false;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = transform.Find("SpriteRenderer").GetComponent<SpriteRenderer>();

        enemyHit = 0;
    }

    void Update()
    {
    }

    IEnumerator EnemyTakeDamageColour()
    {
        enemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemySpriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        enemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemySpriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ProjectilePlayer"))
        {
            enemyHit++;
            StartCoroutine(EnemyTakeDamageColour());
        }

        if (enemyHit >= hitPointsMax)
        {
            KillMe();
        }
    }

    private void KillMe()
    {
        GameObject Corpse = new GameObject("enemyCorpse");
        SpriteRenderer corpseRenderer = Corpse.AddComponent<SpriteRenderer>();
        Corpse.transform.position = transform.position;
        corpseRenderer.sprite = corpseSprite;

        corpseRenderer.flipX = enemySpriteRenderer.flipX;
        Corpse.transform.localScale = transform.localScale;

        Destroy(gameObject);
    }

    public void KnockMeBack(float magnitude, Vector2 direction)
    {
        direction = direction.normalized;
        enemyRb.AddForce(magnitude * direction);
        Debug.Log(direction);
    }
}
