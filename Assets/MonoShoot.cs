using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoShoot : MonoBehaviour
{
    private float timeBtwShots;
    private float shootCounter;
    public float startTimeBtwShots;
    public float fireRate;
    
    public Transform firePoint;
    public GameObject paintShoot;

    void Start()
    {
        shootCounter =  0;
        timeBtwShots = fireRate;
        FindObjectOfType<BossFight>().shootDelagate += MonoShoots;
    }

    public void MonoShoots()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(paintShoot, firePoint.position, Quaternion.identity);
            timeBtwShots = fireRate;
            shootCounter++;

            if (shootCounter==5)
            {
                shootCounter = 0;
            }           
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
