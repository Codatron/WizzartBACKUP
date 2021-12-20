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

    int spawnEnemycounter;
    int maxEnemy = 10;
    private float nextSpawn;
    public float spawnRate = 0.002f;

    private void Start()
    {
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);

        stage = Stage.WatingToStart;
        StartBattle();

    }

    private void Update()
    {
        if (stage == Stage.Stage_1)
        {
            
        }

        if (stage == Stage.Stage_2)
        {
            SpawnEnemy();
        }

        if (stage == Stage.Stage_3)
        {
            
        }

        if (stage == Stage.Dead)

        {
            DestroyAllEnemy();
        }
    }

    private void StartBattle()
    {
        stage = Stage.Stage_1;
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

