using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject objectToSpaw;
    public GameObject bombSpawnPlace;
    public float spawnRate = 3f;
    
    private float lifeTime = 15f;
    private float nextSpawn = 2f;
    private int maxPickUp = 1;
    public int bombSpawnCounter = 0;

    private void Update()
    {
        spawnPickUp();
    }

    void spawnPickUp()
    {
        if (bombSpawnCounter < maxPickUp)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 whereToSpawn = new Vector2(bombSpawnPlace.transform.position.x, bombSpawnPlace.transform.position.y);
            GameObject clone = Instantiate(objectToSpaw, whereToSpawn, Quaternion.identity);
            bombSpawnCounter++;          
        }    
    }
}
