using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHealth : MonoBehaviour
{
    public int currentHealth;
    BossFight bossFight;
    public SpriteRenderer monoSpriteRenderer;

    private void Start()
    {
        currentHealth = 100;      
        bossFight = FindObjectOfType<BossFight>();
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(MonoTakeDamageColour());

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

    IEnumerator MonoTakeDamageColour()
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


