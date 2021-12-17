using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public Rigidbody2D rb;
    private int strength = 350;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<IGetKnockedBack>() != null)
        {
            IGetKnockedBack refKnockBack = other.gameObject.GetComponent<IGetKnockedBack>();
            //Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            //Vector2 otherPos = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            Debug.Log(other.gameObject.name);
            refKnockBack.KnockMeBack(strength, (rb.velocity.normalized));
        }
    }
}

//public float knockbackStrength;

// private void OnCollisionEnter2D(Collision2D collision)
// {
//     Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

//     if (rb != null)
//     {
//         Vector3 direction = collision.gameObject.transform.position - transform.position;
//         rb.AddForce(direction.normalized * knockbackStrength, ForceMode2D.Impulse);
//     }
// }