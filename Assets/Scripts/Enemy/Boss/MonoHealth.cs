using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHealth : MonoBehaviour
{
    public int currentHealth = 20;
    public static bool isEnemyDead = false;

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0 && isEnemyDead == false)
        {
           // gameObject.GetComponent<Animator>().Play("Dying");
            isEnemyDead = true;

            //hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage); + damage lägg till på bullet
        }
    }
}
