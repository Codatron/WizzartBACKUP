using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public enum Stage
    {
        WatingToStart,
        Stage_1,
        Stage_2,
        Stage_3,
        Dead,
    }

    public Stage stage;

    //TO DO LAGG IN TRIGGER FOR ATT STARTA

    List<GameObject> prefabList = new List<GameObject>();
    public List<Transform> spawnPositionList = new List<Transform>();
    List<GameObject> enemySpawnList = new List<GameObject>();

    public GameObject paintEnemy1;
    public GameObject paintEnemy2;
    //public GameObject[] spawnPoints;


    int spawnEnemycounter;
    int maxEnemy = 10;

    private void Start()
    {
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);

      

        stage = Stage.WatingToStart;
        StartBattle();

        Debug.Log("MAYA");
    }

    private void Update()
    {
        if (stage == Stage.Stage_1)
        {
            Debug.Log("HAHAHA");
            SpawnEnemy();
        }

        if (stage == Stage.Dead)

        {
            DestroyAllEnemy();
        }

        Debug.Log("MAYA");
    }


    private void StartBattle()
    {
        stage = Stage.Stage_1;
        //SpawnEnemy();
        //TODO LAGG IN KOD for hur ofta de ska spawn?

    }

    private void SpawnEnemy()

    {// random prefab + position

        if (spawnEnemycounter < maxEnemy)
        {

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

