using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHit : MonoBehaviour, IGetKnockedBack
{
    public AudioClip clipHit;
    public SpriteRenderer enemySpriteRenderer;
    public Transform slideTarget;
    public Sprite corpseSprite;
    public GameObject lipsSmallPrefab;
    public int hitPointsMax;
    public int numberInSwarm;
    public int enemyHit;

    private AudioSource audioSource;
    private Rigidbody2D enemyRb;
    private Transform lipsBig;
    private bool isDead;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = transform.Find("SpriteRenderer").GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        enemyHit = 0;
        hitPointsMax= 10;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ProjectilePlayer"))
        {
            enemyHit++;
            audioSource.PlayOneShot(clipHit);
            StartCoroutine(EnemyTakeDamageColour());
            Debug.Log(enemyHit);
        }

        if (enemyHit >= hitPointsMax && !isDead)
        {
            isDead = true;


            GameManager.PlaySFXDirty(clipHit, 0.2f);

            if (gameObject.CompareTag("EnemyLollipopGirlBlue"))
            {
                
                KillMeRollergirl();
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
        Destroy(gameObject);
        GameObject Corpse = new GameObject("enemyCorpse");
        SpriteRenderer corpseRenderer = Corpse.AddComponent<SpriteRenderer>();
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

        Destroy(corpseCapCollider, 0.5f);

        
    }

    private void KillMeLipsBig(int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            float smallLipsSpawnPosX = Random.Range(-2.0f, 2.0f);
            float smallLipsSpawnPosY = Random.Range(-2.0f, 2.0f);

            Instantiate(lipsSmallPrefab, transform.position + new Vector3(smallLipsSpawnPosX, smallLipsSpawnPosY), Quaternion.identity);
        }

        //LAGG TÌLL LISTA

        Destroy(gameObject);
    }

    public void KnockMeBack(float magnitude, Vector2 direction)
    {
        direction = direction.normalized;
        enemyRb.AddForce(magnitude * direction);
    }
}


