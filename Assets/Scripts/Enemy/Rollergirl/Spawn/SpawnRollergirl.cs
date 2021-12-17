using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRollergirl: MonoBehaviour
{
    public GameObject enemyBlue;
    public GameObject enemyPink;

    public float spawnRate = 3f;
    float grassSpawnPosX;
    float grassSpawnPosY;
    float grassBottomSpawnPosX;
    float grassBottomSpawnPosY;
    float mailBoxSpawnPosX;
    float mailBoxSpawnPosY;
    float nextSpawn = 2f;
    int maxEnemies = 100;
    int enemyCounter;

    Vector2 whereToSpawn;
   
    void Start()
    {
         enemyCounter = 0;
    }
    void Update()
    {  
        //When time passed is greater than the spawnRate, spawn an enemy at a random position X and Y
        if (Time.time > nextSpawn && enemyCounter < maxEnemies)   
        {
            nextSpawn = Time.time + spawnRate;
            grassSpawnPosX = Random.Range(-39f, 27f);        //Random pos X Change values to increase random range
            grassSpawnPosY = Random.Range(-30f, -45f);        //Random pos Y Change values to increase random range
            whereToSpawn = new Vector2(grassSpawnPosX, grassSpawnPosY);
            GameObject cloneEnemy = Instantiate(enemyBlue, whereToSpawn, Quaternion.identity);
            GameObject clonePink = Instantiate(enemyPink, whereToSpawn, Quaternion.identity);

            grassBottomSpawnPosX = Random.Range(-20f, 48f);        //Random pos X Change values to increase random range
            grassBottomSpawnPosY = Random.Range(-104f, -123f);        //Random pos Y Change values to increase random range
            whereToSpawn = new Vector2(grassBottomSpawnPosX, grassBottomSpawnPosY);
            GameObject cloneEnemyBottom = Instantiate(enemyBlue, whereToSpawn, Quaternion.identity);
            GameObject clonePinkBottom = Instantiate(enemyPink, whereToSpawn, Quaternion.identity);

            mailBoxSpawnPosX = Random.Range(-105f, 85f);        //Random pos X Change values to increase random range
            mailBoxSpawnPosY = Random.Range(-80f, -90f);        //Random pos Y Change values to increase random range
            whereToSpawn = new Vector2(mailBoxSpawnPosX, mailBoxSpawnPosY);
            GameObject cloneEnemyMailBox = Instantiate(enemyBlue, whereToSpawn, Quaternion.identity);
            GameObject clonePinkMailBox = Instantiate(enemyPink, whereToSpawn, Quaternion.identity);
            enemyCounter++;                         //Counts enemies spawned, used for reaching max amount of enemies
        } 
    }
}