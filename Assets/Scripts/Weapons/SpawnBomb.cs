using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{

    public GameObject objectToSpaw;
    public float spawnRate = 3f;
    
    private float lifeTime = 15f;
    private float nextSpawn = 2f;
    private int maxPickUp = 1;
    private int pickUpCounter;

    private void Update()
    {
        spawnPickUp();
    }

    void spawnPickUp()
    {
        if (Time.time > nextSpawn && pickUpCounter < maxPickUp)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 whereToSpawn = new Vector2(Random.Range(-14f, 14f), Random.Range(-25f, 25f));
            GameObject clone = Instantiate(objectToSpaw, whereToSpawn, Quaternion.identity);
            pickUpCounter++;

            Destroy(clone, lifeTime);
        }

        pickUpCounter = 0;
    }
}
