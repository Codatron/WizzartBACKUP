using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private Camera cam;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Slider slider;
    public AudioSource speaker;
    public AudioClip refill;
    public AudioClip shoot;
    public float force = 800f;      // If we want to fire the bullet using force instead

    public float angle;
    public int ammoCount;

    bool reloading = false;

    void Start()
    {
        cam = Camera.main;

        ammoCount = 10;
        slider.maxValue = ammoCount;
    }
    public void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector2 offSet = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //shoot 
        if (Input.GetMouseButtonDown(0) && ammoCount > 0 && reloading == false)
        {
            Fire(offSet);
            speaker.PlayOneShot(shoot);
            ammoCount--;
            reloading = true;
            slider.value = ammoCount;
            Invoke("ReloadingGun", 0.2f);
        }


        if (Input.GetKeyDown("r"))
        {
            ammoCount = 20;
            speaker.PlayOneShot(refill);
            reloading = true;
            Invoke("ReloadingGun", 3f);
            
        }
    }

    void ReloadingGun()
    {
        reloading = false;
    }

    public void RefillAmmo(int ammo)
    {
        ammoCount = ammo;
        slider.value = ammoCount;
    }

    public void Fire(Vector2 offset)
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation).GetComponent<Bullet>();
        bullet.FireMe(offset);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}