using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopAttackPink : MonoBehaviour
{
    public GameObject lollipop;
    public float fireRate;
    
    float timeBtwShots;

    void Start()
    {
        timeBtwShots = fireRate;
    }

    void Update()
    {
        //Governs how long it takes for the enemy to attack again
        if (timeBtwShots <= 0)
        {
            Instantiate(lollipop, transform.position, Quaternion.identity);
            timeBtwShots = fireRate;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
