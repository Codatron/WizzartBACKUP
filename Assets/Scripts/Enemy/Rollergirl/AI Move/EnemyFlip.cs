using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public Sprite enemySpriteFront;
    public Sprite enemySpriteBack;
    public SpriteRenderer enemySpriteRenderer;
    //public Transform firePoint;

    private Transform player;
    private bool isOverY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemySpriteRenderer.flipX = player.position.x < transform.position.x;
        isOverY = player.position.y > transform.position.y;
        enemySpriteRenderer.sprite = isOverY ? enemySpriteBack : enemySpriteFront;

        //if (enemySpriteRenderer.flipX)
        //{
        //    firePoint.localScale = new Vector3(-0.175f, -0.175f, 1.0f);
        //}
        //else
        //{
        //    firePoint.localScale = new Vector3(0.175f, 0.175f, 1.0f);
        //}
    }
}
