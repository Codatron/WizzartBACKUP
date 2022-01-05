using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoHealth : MonoBehaviour
{
    public Slider slider;
    public SpriteRenderer monoSpriteRenderer;

    private int maxHealth = 400;
    private int currentHealth;
    private BossFight bossFight;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(currentHealth);
        bossFight = FindObjectOfType<BossFight>();
    }

    void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    void SetCurrentHealth(int health)
    {
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(MonoTakeDamageColour());

        if (bossFight.stage == BossFight.Stage.Dead)
        {
            return;
        }

        currentHealth -= damage;
        SetCurrentHealth(currentHealth);

        if (currentHealth < 350 && bossFight.stage == BossFight.Stage.Idel) //ANDRA TO STAGE 1
        {
            bossFight.stage = BossFight.Stage.Stage_1;            
            return;
        }

        if (currentHealth < 200 && bossFight.stage == BossFight.Stage.Stage_1)
        {
            bossFight.stage = BossFight.Stage.Stage_2;            
            return;
        }

        if (currentHealth < 100 && bossFight.stage == BossFight.Stage.Stage_2)
        {         
            bossFight.stage = BossFight.Stage.Stage_3;       
            return;
        }

        if (currentHealth < 50 && bossFight.stage == BossFight.Stage.Stage_3)
        {
            bossFight.stage = BossFight.Stage.Stage_4;
            return;           
        }

        if (currentHealth <= 0 && bossFight.stage == BossFight.Stage.Stage_4)
        {
            bossFight.stage = BossFight.Stage.Dead;          
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


