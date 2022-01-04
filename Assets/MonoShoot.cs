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

    public GameObject paintShoot1;
    public GameObject paintShoot2;
    public GameObject paintShoot3;
    public GameObject paintShoot4;
    public GameObject paintShoot5;
    public GameObject paintShoot6;

    public List<GameObject> monoShootPaint = new List<GameObject>();

    void Start()

    {

        monoShootPaint.Add(paintShoot1);
        monoShootPaint.Add(paintShoot2);
        monoShootPaint.Add(paintShoot3);
        monoShootPaint.Add(paintShoot4);
        monoShootPaint.Add(paintShoot5);
        monoShootPaint.Add(paintShoot6);
        

        shootCounter =  0;
        timeBtwShots = fireRate;
        FindObjectOfType<BossFight>().shootDelagate += MonoShoots;
    }

    public void MonoShoots()
    {
        if (timeBtwShots <= 0)
        {
		gameObject.GetComponent<Animator>().Play("Attack1");
            int monoShootRandom = UnityEngine.Random.Range(0, monoShootPaint.Count);
            Instantiate(monoShootPaint[monoShootRandom], firePoint.position, Quaternion.identity);
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
