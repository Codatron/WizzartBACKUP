using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GameObject[] wineProjectiles;
    //public GameObject bulletPrefab;
    public GameObject bombNoHandsPrefab;
    public GameObject dropBombPos;
    public Transform firePoint;
    public Slider slider;
    public AudioSource speaker;
    public AudioClip refill;
    public AudioClip shoot;
    public float speed;      
    public int ammoCount;

    private Camera cam;
    private BoolKeeper refBoolKeeper;
    private float angle;
    private int projectileIndex = 4;
    private SpriteRenderer gunSpriteRenderer;
    private SpriteRenderer bombHandsSpriteRenderer;
    private SpriteRenderer whiteMuzzleFlashSpriteRenderer;


    void Start()
    {
        cam = Camera.main;

        ammoCount = 20;
        slider.maxValue = ammoCount;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();

        gunSpriteRenderer = GetComponent<SpriteRenderer>();
        bombHandsSpriteRenderer = GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>();

        whiteMuzzleFlashSpriteRenderer = GameObject.FindGameObjectWithTag("MuzzleFlashWhite").GetComponent<SpriteRenderer>();
        //whiteMuzzleFlashSpriteRenderer.enabled = false;
    }

    public void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
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
        if (Input.GetMouseButton(0) && ammoCount > 0 && refBoolKeeper.dontShoot == false)
        {
            Fire();
            speaker.PlayOneShot(shoot);
            ammoCount--;
            refBoolKeeper.dontShoot = true;
            slider.value = ammoCount;
            Invoke("DontShoot", 0.2f);

            gunSpriteRenderer.enabled = true;

            if (bombHandsSpriteRenderer.enabled == true)
            {
                GameObject clone = Instantiate(bombNoHandsPrefab, dropBombPos.transform.position, Quaternion.identity);
                bombHandsSpriteRenderer.enabled = false;
            }             
        }
    }

    public void Fire()
    {
        int randomProjectile = (int)Random.Range(0, 3);
        
        GameObject bulletClone = Instantiate(wineProjectiles[randomProjectile], firePoint.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        //whiteMuzzleFlashSpriteRenderer.enabled = true;

        //TODO: disable muzzle flash after firing
        // is it better to use the Sprite Renderer to do this or to Instantiate then Destroy instead?
        // Interesting: When all whiteMuzzleFlashSpriteRenderer are NOT commented out and the Circle Game Object is manually deactivated in the inspector, something really cool happens...
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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}