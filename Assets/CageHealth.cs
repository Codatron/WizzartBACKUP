using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CageHealth : MonoBehaviour
{
    public int health;
    public Sprite cage_1;
    public Sprite cage_2;
    public Sprite cage_3;
    public Sprite cage_4;
    public Sprite cage_5;
    public Transform camera2;
    public GameObject moveCameraTo;
    public MoveCamera moveCamera;
    public GameObject startDialogCage;
    public CircleCollider2D circleCol;
    public AudioClip clipBrokenGlass;
    public bool startDialog = false;
    public int spriteRend = 0;
    public bool pickUpBomb = false;

    private AudioSource speaker;
    private PlayerController playerController;
    private PlayerHit playerHit;
    private SpriteRenderer cageSprRend;
    private Vector3 cameraOrgPos;
    private bool OnlyOnce = true;

    GameObject player;
   public AudioSource playerAudio;

    void Start()
    {        
        health = 30;
        playerController = FindObjectOfType<PlayerController>();
        playerHit = FindObjectOfType<PlayerHit>();
        cageSprRend = GetComponent<SpriteRenderer>();
        speaker = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");

        playerAudio= player.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (spriteRend == 1)
        {
            cageSprRend.sprite = cage_4;
        }

        if (spriteRend == 2)
        {
            cageSprRend.sprite = cage_5;
        }

        playerAudio.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ProjectilePlayer"))
        {
            health--;
            HealthCage();
            Destroy(other.gameObject);
        }
    }

    public void HealthCage()
    {          
        if (health % 10 == 0)
        {
            GameManager.PlaySFXDirty(clipBrokenGlass, 2.0f);
        }

        if (health < 20 )
        {
            cageSprRend.sprite = cage_2;
        }

        if (health < 10)
        {
            cageSprRend.sprite = cage_3;
        }

        if (health <= 0 && OnlyOnce) 
        {
            OnlyOnce = false;            
            moveCamera.CameraMoveTo(moveCameraTo);
            playerController.StartDialog(startDialogCage);

            pickUpBomb = true;      
            Destroy(circleCol);
            startDialog = true;

            playerAudio.enabled = false;         
            playerHit.playerHealthCurrent = 20;

            
        }
    }
}
