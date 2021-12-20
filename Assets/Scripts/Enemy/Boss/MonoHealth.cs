using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHealth : MonoBehaviour
{
    public int currentHealth;
    BossFight bossFight;

    private void Start()
    {
        currentHealth = 100;
        Debug.Log(currentHealth + "hej");
        bossFight = FindObjectOfType<BossFight>();
    }

    public void TakeDamage(int damage)
    {
        
        if (bossFight.stage == BossFight.Stage.Dead)
        {
            return;
        }

        currentHealth -= damage;
        Debug.Log(currentHealth + "hej");

        if (currentHealth < 70 && bossFight.stage == BossFight.Stage.WatingToStart) //ANDRA TO STAGE 1
        {
            bossFight.stage = BossFight.Stage.Stage_1;
            Debug.Log("StageTEST");
            return;
        }

        if (currentHealth < 50 && bossFight.stage == BossFight.Stage.Stage_1)
        {
            bossFight.stage = BossFight.Stage.Stage_2;
            Debug.Log("Stage1");
            return;
        }

        if (currentHealth < 30 && bossFight.stage == BossFight.Stage.Stage_2)
        {
            bossFight.stage = BossFight.Stage.Stage_3;
            Debug.Log("Stage2");
            return;
        }


        if (currentHealth <= 0 && bossFight.stage == BossFight.Stage.Stage_3)
        {
            bossFight.stage = BossFight.Stage.Dead;
           
            // gameObject.GetComponent<Animator>().Play("Dying");
        }
    }
}


