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

    private BoolKeeper refBoolKeeper;
    private SpriteRenderer gunSpriteRenderer;
    private SpriteRenderer bombHandsSpriteRenderer;
    private SpriteRenderer muzzleFlashSpriteRenderer;

    //TODO ingen ref tillbombhands och ta bort boolkeeper
    void Start()
    {
        ammoCount = 50;
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

        if (ammoCount==0 && refBoolKeeper.dontShoot == false)
        {
            Reload();
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
            }             
        }
    }

    public void Fire()
    {
        int randomProjectile = (int)Random.Range(0, wineProjectiles.Length);
        
        GameObject bulletClone = Instantiate(wineProjectiles[randomProjectile], firePoint.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        //TODO: disable muzzle flash after firing
        // is it better to use the Sprite Renderer to do this or to Instantiate then Destroy instead?
        // Interesting: When all whiteMuzzleFlashSpriteRenderer are NOT commented out and the Circle Game Object is manually deactivated in the inspector, something really cool happens...
    }

    private void Reload()
    {              
            ammoCount = 50;
            speaker.PlayOneShot(refill);
            refBoolKeeper.dontShoot = true;
            Invoke("DontShoot", 1.5f);     
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
}