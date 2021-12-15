using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollergirlAttack : MonoBehaviour
{
    public GameObject lollipopPrefab;
    public float fireRate;

    private GameObject lollipopClone;
    private float timeBtwShots;

    void Start()
    {
        timeBtwShots = fireRate;
    }

    void Update()
    {
        ShootLollipop();
    }

    void ShootLollipop()
    {
        //Governs how long it takes for the enemy to attack again
        if (timeBtwShots <= 0)
        {
            Instantiate(lollipopPrefab, transform.position, Quaternion.identity);
            //lollipopClone.GetComponent<Rigidbody2D>().velocity = transform.rigth * ;
            Debug.Log("lollipopClone");
            
            timeBtwShots = fireRate;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
