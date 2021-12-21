using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainCircleSpawn : MonoBehaviour
{
    public int numberOfPaintBlobs;

    float radius;
    float speed;
    int delay;

    public GameObject paintBlobs;
    public GameObject startPoint;
    public Vector3 spawnPosition;

    BossFight bossFight;

    void Start()
    {
        radius = 5f;
        speed = 7f;

        bossFight = FindObjectOfType<BossFight>();       
    }
    
    void Update()
    {    
        spawnPosition = startPoint.transform.position;

        if (bossFight.stage == BossFight.Stage.Stage_1)
        {
            if (!IsInvoking(nameof(SpawnPaintBlobs)))
            {
                Invoke(nameof(SpawnPaintBlobs),0);
            }
        }  
    }

    void SpawnPaintBlobs()
    {
        float angleSteps = 360f / numberOfPaintBlobs;
        float angle = 0f;

        for (int i = 0; i <= numberOfPaintBlobs - 1; i++)
        {
            float paintBlobsDirX = spawnPosition.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float paintBlobsDirY = spawnPosition.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 paintBlobsVector = new Vector2(paintBlobsDirX, paintBlobsDirY);
            Vector3 paintBlobsMoveDirection = (paintBlobsVector - spawnPosition).normalized * speed;

            GameObject painBlobClone = Instantiate(paintBlobs, spawnPosition, Quaternion.identity);

            painBlobClone.GetComponent<Rigidbody2D>().velocity = new Vector2(paintBlobsMoveDirection.x, paintBlobsMoveDirection.y);
            Destroy(painBlobClone, 3);
            angle += angleSteps;           
        }

        delay++;//test
        delay %= 3;//test
        Invoke(nameof(SpawnPaintBlobs), 2+delay);//tva minsta tid
       
    }
}
