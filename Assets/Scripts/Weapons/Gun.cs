using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bomb;
    public GameObject dropBombPlace;
    public Transform firePoint;
    public Slider slider;
    public AudioSource speaker;
    public AudioClip refill;
    public AudioClip shoot;
    public float speed;      
    public int ammoCount;

    private Camera cam;
    private float angle;
    private BoolKeeper refBoolKeeper;

    void Start()
    {
        cam = Camera.main;

        ammoCount = 20;
        slider.maxValue = ammoCount;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();
    }
    public void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector2 offSet = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        ShootGun();
        Reload();
    }

    private void Reload()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.R) && refBoolKeeper.dontShoot == false)
        {
            ammoCount = 20;
            speaker.PlayOneShot(refill);
            refBoolKeeper.dontShoot = true;
            Invoke("DontShoot", 1.5f);
        }
    }

    private void ShootGun()
    {
        if (Input.GetMouseButtonDown(0) && ammoCount > 0 && refBoolKeeper.dontShoot == false)
        {
            Fire();
            speaker.PlayOneShot(shoot);
            ammoCount--;
            refBoolKeeper.dontShoot = true;
            slider.value = ammoCount;
            Invoke("DontShoot", 0.2f);

            
            GetComponent<SpriteRenderer>().enabled = true;

            if (GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>().enabled == true)
            {
                GameObject clone = Instantiate(bomb, dropBombPlace.transform.position, Quaternion.identity);
                GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>().enabled = false;
            }             
        }
    }

    public void Fire()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Debug.Log("Fire");
    }

    void DontShoot()
    {
        refBoolKeeper.dontShoot = false;
    }

    public void RefillAmmo(int ammo)
    {
        ammoCount = ammo;
        slider.value = ammoCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}