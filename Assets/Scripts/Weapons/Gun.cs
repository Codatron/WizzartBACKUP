using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GameObject[] wineProjectiles;
    public GameObject bombNoHandsPrefab;
    public GameObject dropBombPos;
    public Transform firePoint;
    public AudioSource speaker;
    public AudioClip refill;
    public AudioClip shoot;
    public float speed;      
    public int ammoCount;
    public Integer2 ammoRef;

    private int ammoMax = 50;
    private BoolKeeper refBoolKeeper;
    private SpriteRenderer gunSpriteRenderer;
    private SpriteRenderer bombHandsSpriteRenderer;
    private SpriteRenderer muzzleFlashSpriteRenderer;

    //TODO ingen ref tillbombhands och ta bort boolkeeper
    public PickUpBomb pickUpBomb;
    void Start()
    {
        ammoCount = ammoMax;
        ammoRef.integerB = ammoCount;

        refBoolKeeper = GameObject.FindGameObjectWithTag("BoolKeeper").GetComponent<BoolKeeper>();

        gunSpriteRenderer = GetComponent<SpriteRenderer>();
        bombHandsSpriteRenderer = GameObject.FindGameObjectWithTag("BombHands").GetComponent<SpriteRenderer>();
        muzzleFlashSpriteRenderer = GameObject.FindGameObjectWithTag("MuzzleFlash").GetComponent<SpriteRenderer>();
        
        muzzleFlashSpriteRenderer.enabled = false;

        

    }

    public void Update()
    {
        ShootGun();
        
        ammoRef.integerA = ammoCount;

        if (ammoCount <= 0 && refBoolKeeper.dontShoot == false)
        {
            Reload(ammoMax);
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
            muzzleFlashSpriteRenderer.enabled = true;
            
            Invoke("DontShoot", 0.125f);
            Invoke("Muzzle", 0.05f);

            gunSpriteRenderer.enabled = true;

            if (bombHandsSpriteRenderer.enabled == true)
            {
                GameObject clone = Instantiate(bombNoHandsPrefab, dropBombPos.transform.position, Quaternion.identity);
                bombHandsSpriteRenderer.enabled = false;
                StartCoroutine("allowPickUp");
            }             
        }
    }

    public void Fire()
    {
        int randomProjectile = (int)Random.Range(0, wineProjectiles.Length);
        
        GameObject bulletClone = Instantiate(wineProjectiles[randomProjectile], firePoint.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void Reload(int ammoToRefill)
    {              
            //ammoCount = 50;
            refBoolKeeper.dontShoot = true;
            Invoke("DontShoot", 1.0f);
            speaker.PlayOneShot(refill);
            //RefillAmmo(ammoCount);
            ammoCount = ammoToRefill;
    }

    void DontShoot()
    {
        refBoolKeeper.dontShoot = false;
    }

    void Muzzle()
    {
        muzzleFlashSpriteRenderer.enabled = false;
    }

    public void RefillAmmo(int ammo)
    {
        ammoCount = ammo;
    }

    IEnumerator allowPickUp()
    {
        yield return new WaitForSeconds(0.1f);
        pickUpBomb.allowed = true;
    }
}