using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHit : MonoBehaviour, IGetKnockedBack
{
    public SpriteRenderer enemySpriteRenderer;
    public Transform slideTarget;
    public Sprite corpseSprite;
    public GameObject lipsSmallPrefab;
    public int hitPointsMax;
    public int numberInSwarm;

    private Rigidbody2D enemyRb;
    Transform lipsBig;
    public int enemyHit;

    bool isDead;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = transform.Find("SpriteRenderer").GetComponent<SpriteRenderer>();
       
        enemyHit = 0;

        isDead = false;
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

    // TODO: 
    // - why does enemyHit increase by two sometimes?
    // - Clue ? If circle collider is removed then everything works as it should.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ProjectilePlayer"))
        {
            enemyHit++;
            StartCoroutine(EnemyTakeDamageColour());
            // play audio
            Debug.Log(enemyHit);
        }

        if (enemyHit >= hitPointsMax && !isDead)
        {
            isDead = true;

            if(gameObject.CompareTag("EnemyLollipopGirlBlue"))
            {
                KillMeRollergirl();
                // play audio
            }

            if (gameObject.CompareTag("EnemyLipsBig"))
            {
                KillMeLipsBig(numberInSwarm);
            }

            if (gameObject.CompareTag("EnemyLipsSmall"))
            {
                Destroy(gameObject);
            }
        }
    }

    // TODO: 
    // - why do two corpses appear sometimes?
    private void KillMeRollergirl()
    {
        GameObject Corpse = new GameObject("enemyCorpse");
        SpriteRenderer corpseRenderer = Corpse.AddComponent<SpriteRenderer>();
        Destroy(gameObject);
        Rigidbody2D corpseRb = Corpse.AddComponent<Rigidbody2D>();
        CapsuleCollider2D corpseCapCollider = Corpse.AddComponent<CapsuleCollider2D>();
        
        corpseRb.gravityScale = 0.0f;
        corpseRb.freezeRotation = true;
        
        corpseCapCollider.direction = CapsuleDirection2D.Horizontal;
        corpseCapCollider.size = new Vector2(1.77f, 0.36f);
        corpseCapCollider.offset = new Vector2(0.0f, -0.17f);

        Corpse.transform.position = transform.position;
        corpseRenderer.sprite = corpseSprite;
        corpseRenderer.flipX = enemySpriteRenderer.flipX;
        Corpse.transform.localScale = transform.localScale;

        Vector2 slideDirection = (slideTarget.position - Corpse.transform.position).normalized;
        Vector2 slideForce = slideDirection * 600f;
        corpseRb.AddForce(slideForce);
        corpseRb.drag = 1.25f;

        Destroy(corpseCapCollider, 0.75f);

        
    }

    private void KillMeLipsBig(int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            float smallLipsSpawnPosX = Random.Range(-2.0f, 2.0f);
            float smallLipsSpawnPosY = Random.Range(-2.0f, 2.0f);

            Instantiate(lipsSmallPrefab, transform.position + new Vector3(smallLipsSpawnPosX, smallLipsSpawnPosY), Quaternion.identity);
        }

        Destroy(gameObject);
    }

    public void KnockMeBack(float magnitude, Vector2 direction)
    {
        direction = direction.normalized;
        enemyRb.AddForce(magnitude * direction);
    }
}


