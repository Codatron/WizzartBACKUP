using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollergirlAttack : MonoBehaviour
{
    public GameObject lollipopPrefab;
    public Transform firePoint;
    public float fireRate;

    private GameObject lollipopClone;
    private EnemyAIPathfind refEnemyAIPAthfind;
    private float timeBtwShots;

    void Start()
    {
        timeBtwShots = fireRate;
        refEnemyAIPAthfind = GetComponent<EnemyAIPathfind>();
    }

    void Update()
    {
        if (refEnemyAIPAthfind.isTargetWithinRange)
        {
            ShootLollipop();
        }
    }

    void ShootLollipop()
    {
        //Governs how long it takes for the enemy to attack again
        if (timeBtwShots <= 0)
        {
            Instantiate(lollipopPrefab, firePoint.position, Quaternion.identity);
            //lollipopClone.GetComponent<Rigidbody2D>().velocity = transform.rigth * ;
            
            timeBtwShots = fireRate;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
