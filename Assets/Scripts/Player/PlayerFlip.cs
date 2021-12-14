using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    GameObject gun;
    GameObject bomb;
    Gun refGun;
    PickUpBomb refPickUpBomb;
    Transform firePoint;
    SpriteRenderer playerSpriteRenderer;
    SpriteRenderer gunSpriteRenderer;
    SpriteRenderer bombSpriteRenderer;
    public Sprite playerSpriteBack;
    public Sprite playerSpriteFront;
    bool isOverY;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
        refGun = gun.GetComponent<Gun>();

        bomb = GameObject.FindGameObjectWithTag("BombHands");
        refPickUpBomb = bomb.GetComponent<PickUpBomb>();

        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gunSpriteRenderer = gun.GetComponent<SpriteRenderer>();
        bombSpriteRenderer = bomb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerSpriteRenderer.flipX = refGun.firePoint.position.x > gameObject.transform.position.x;
        gunSpriteRenderer.flipY = !(refGun.firePoint.position.x > gameObject.transform.position.x);
        isOverY = refGun.firePoint.position.y > gameObject.transform.position.y;
        playerSpriteRenderer.sprite = isOverY ? playerSpriteBack : playerSpriteFront;
        gunSpriteRenderer.sortingOrder = isOverY ? 0 : 2;


        bombSpriteRenderer.flipX = refGun.firePoint.position.x > gameObject.transform.position.x;
        isOverY = refGun.firePoint.position.y > gameObject.transform.position.y;
        bombSpriteRenderer.sortingOrder = isOverY ? 0 : 2;
        bombSpriteRenderer.flipX = isOverY ? true : false;
        // TODO : Program the bomb pacement so that it is in accordance with the directionthe player is facing and also on which side of the body that the bom is on at that particular time. 14/12/2021


        //if (isOverY)
        //{
        //    playerSpriteRenderer.sprite = playerSpriteBack;
        //    gunRenderer.sortingOrder = 0;
        //}
        //else
        //{
        //    playerSpriteRenderer.sprite = playerSpriteFront;
        //    gunRenderer.sortingOrder = 2;
        //}

    }
}
