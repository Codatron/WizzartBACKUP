using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLips: MonoBehaviour
{
    public Transform target;
    public Rigidbody2D lipsPrefab;
    public float spawnRate = 3.0f;
    public float alertDistance;

    private float distanceToTarget;
    private float nextSpawn = 1.0f;
    private bool isWithinRange;

    public List<Rigidbody2D> cloneBigLipsList = new List<Rigidbody2D>();

 
    void Update()
    {

        distanceToTarget = Vector2.Distance(target.position, transform.position);

        isWithinRange = false;

        if (distanceToTarget <= alertDistance)
        {
            isWithinRange = true;

            if (Time.time > nextSpawn && isWithinRange)
            {
                nextSpawn = Time.time + spawnRate;
                SpawnBigLips();
            }
        }
        else
        {
            isWithinRange = false;
        }
    }

    void SpawnBigLips()
    {
        Rigidbody2D lipsClone = Instantiate(lipsPrefab, transform.position + new Vector3(0.0f, 1.0f), Quaternion.identity);
        cloneBigLipsList.Add(lipsClone);

        //Spara i lista
    }


    public void DestroyBigLips()
    {

        foreach (Rigidbody2D lipsClone in cloneBigLipsList)
        {
            Debug.Log("HEJ2");
            Destroy(GameObject.FindWithTag("EnemyLipsBig"));
        }
    }
}



//public GameObject enemyBlue;
//public GameObject enemyPink;

//private float randX;
//private float randY;
//private int maxEnemies = 100;
//private int enemyCounter;

//Vector2 whereToSpawn;
////When time passed is greater than the spawnRate, spawn an enemy at a random position X and Y
//if (Time.time > nextSpawn && enemyCounter < maxEnemies)   
//{
//    nextSpawn = Time.time + spawnRate;
//    randX = Random.Range(21f, 21f);        //Random pos X Change values to increase random range
//    randY = Random.Range(6f, 6f);        //Random pos Y Change values to increase random range
//    whereToSpawn = new Vector2(randX, randY);
//    GameObject cloneEnemy = Instantiate(enemyBlue, whereToSpawn, Quaternion.identity);
//    GameObject clonePink = Instantiate(enemyPink, whereToSpawn, Quaternion.identity);
//    enemyCounter++;                         //Counts enemies spawned, used for reaching max amount of enemies
//} 