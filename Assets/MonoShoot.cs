using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoShoot : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float fireRate;
    public Transform firePoint;
    public GameObject paintShoot;

    void Start()
    {
        timeBtwShots = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonoShoots()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(paintShoot, firePoint.position, Quaternion.identity);
            timeBtwShots = fireRate;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
