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
        bossFight = FindObjectOfType<BossFight>();
    }

    public void TakeDamage(int damage)
    {
        
        if (bossFight.stage == BossFight.Stage.Dead)
        {
            return;
        }

        currentHealth -= damage;       

        if (currentHealth < 80 && bossFight.stage == BossFight.Stage.Idel) //ANDRA TO STAGE 1
        {
            bossFight.stage = BossFight.Stage.Stage_1;            
            return;
        }

        if (currentHealth < 50 && bossFight.stage == BossFight.Stage.Stage_1)
        {
            bossFight.stage = BossFight.Stage.Stage_2;            
            return;
        }

        if (currentHealth < 20 && bossFight.stage == BossFight.Stage.Stage_2)
        {
            bossFight.stage = BossFight.Stage.Stage_3;
        
            return;
        }


        if (currentHealth <= 0 && bossFight.stage == BossFight.Stage.Stage_3)
        {
            bossFight.stage = BossFight.Stage.Dead;
           
            // gameObject.GetComponent<Animator>().Play("Dying");
        }
    }
}


