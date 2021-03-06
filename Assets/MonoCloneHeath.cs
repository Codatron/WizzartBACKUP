using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCloneHeath : MonoBehaviour
{
    public int currentHealth;
    public SpriteRenderer monoSpriteRenderer;
    
    void Start()
    {      
        currentHealth = 30;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ProjectilePlayer") )
        {
            StartCoroutine(MonoTakeDamageColour2());
            currentHealth--;
        }
    }

    IEnumerator MonoTakeDamageColour2()
    {
        monoSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        monoSpriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.05f);
        monoSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        monoSpriteRenderer.color = Color.white;
    }
}
