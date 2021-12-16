using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHealth : MonoBehaviour
{
    public int currentHealth;
    public static bool isEnemyDead = false;
    BossFight bossFight;

    private void Start()
    {
        currentHealth = 100;
        Debug.Log(currentHealth + "hej");
        bossFight = FindObjectOfType<BossFight>();
    }

    public void TakeDamage(int monoDamage)
    {
        currentHealth -= monoDamage;
        Debug.Log(currentHealth + "hej");

        if (currentHealth< 70 && bossFight.stage == BossFight.Stage.WatingToStart)
        {
            bossFight.stage = BossFight.Stage.Stage_2;
            Debug.Log("Stage2");
        }

        if (currentHealth <= 0 && isEnemyDead == false)
        {
           // gameObject.GetComponent<Animator>().Play("Dying");
            isEnemyDead = true;
        }
    }
}
