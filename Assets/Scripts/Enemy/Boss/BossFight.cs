using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public enum Stage
    {
        Idel,
        Movment,
        Stage_1,
        Stage_2,
        Stage_3,
        Dead,
    }

    public Stage stage;

    public List<Transform> spawnPositionList = new List<Transform>();

    List<GameObject> prefabList = new List<GameObject>();
    List<GameObject> enemySpawnList = new List<GameObject>();

    public GameObject paintEnemy1;
    public GameObject paintEnemy2;
    

    int spawnEnemycounter;
    int maxEnemy = 15;
    private float nextSpawn;
    public float spawnRate;
   
    public PaintCircleSpawn paintCircleSpawn;
    public MonoClones MonoClones;
    public MonoShoot MonoShoot;

    private void Start()
    {
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);

        stage = Stage.Idel;
        StartBattle();
    }

    private void Update()
    {
        if (stage == Stage.Idel) //TODO SWITHC
        {

            MonoShoot.MonoShoots();
        }


        if (stage == Stage.Stage_1) //TODO SWITHC
        {

            SpawnEnemy();
            MonoShoot.MonoShoots();
        }

        if (stage == Stage.Stage_2)
        {
            paintCircleSpawn.StartSpawningBlobs();
            SpawnEnemy();
        }

        if (stage == Stage.Stage_3)
        {            
            paintCircleSpawn.StopSpawningBlobs();
            MonoClones.MonoClone();
            MonoShoot.MonoShoots();
            DestroyAllEnemy();
        }

        if (stage == Stage.Dead)
        {
            
        }
    }


    private void StartBattle()
    {
        //stage = Stage.Stage_1;
    }

    private void SpawnEnemy()

    {// random prefab + position
        if (Time.time > nextSpawn && spawnEnemycounter < maxEnemy)
        {
            nextSpawn = Time.time + spawnRate;
            Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)].position;
            int enemyRandom = UnityEngine.Random.Range(0, 2);

            GameObject enemySpawn = Instantiate(prefabList[enemyRandom], spawnPosition, Quaternion.identity);
            spawnEnemycounter++;
            
            enemySpawnList.Add(enemySpawn);
        }
    }

    private void DestroyAllEnemy()
    {
        foreach (GameObject enemySpawn in enemySpawnList)
        {
            Destroy(GameObject.FindWithTag("PaintEnemy"));
        }
    }
}

