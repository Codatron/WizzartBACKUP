using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private SpriteRenderer thisEnemySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        thisEnemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemyTakeDamageColour());
    }

    IEnumerator EnemyTakeDamageColour()
    {
        thisEnemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        thisEnemySpriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        thisEnemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        thisEnemySpriteRenderer.color = Color.clear;
    }

    
}
