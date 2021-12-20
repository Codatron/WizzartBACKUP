using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHit : MonoBehaviour, IGetKnockedBack
{
    public SpriteRenderer enemySpriteRenderer;
    public Sprite corpseSprite;
    public GameObject lipsSmallPrefab;
    public int hitPointsMax;
    public int numberInSwarm;

    private Rigidbody2D enemyRb;
    Transform lipsBig;
    private int enemyHit;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = transform.Find("SpriteRenderer").GetComponent<SpriteRenderer>();
       
        enemyHit = 0;
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
            if(gameObject.CompareTag("EnemyLollipopGirlBlue") || gameObject.CompareTag("EnemyLollipopGirlBlue"))
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

    private void KillMeRollergirl()
    {
        GameObject Corpse = new GameObject("enemyCorpse");
        SpriteRenderer corpseRenderer = Corpse.AddComponent<SpriteRenderer>();
        Corpse.transform.position = transform.position;
        corpseRenderer.sprite = corpseSprite;

        corpseRenderer.flipX = enemySpriteRenderer.flipX;
        Corpse.transform.localScale = transform.localScale;

        Destroy(gameObject);
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
        Debug.Log(direction);
    }
}
