using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Slider slider;
    public AudioSource speaker;
    public AudioClip refill;
    public AudioClip shoot;
    public float speed;      
    public int ammoCount;

    private Camera cam;
    private float angle;

    bool reloading = false;

    void Start()
    {
        cam = Camera.main;

        ammoCount = 20;
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
            Fire();
            speaker.PlayOneShot(shoot);
            ammoCount--;
            reloading = true;
            slider.value = ammoCount;
            Invoke("ReloadingGun", 0.2f);
        }

        if (Input.GetKeyDown("r") && reloading == false)
        {
            ammoCount = 20;
            speaker.PlayOneShot(refill);
            reloading = true;
            Invoke("ReloadingGun", 1.5f);  
        }
    }

    public void Fire()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Debug.Log("Fire");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}