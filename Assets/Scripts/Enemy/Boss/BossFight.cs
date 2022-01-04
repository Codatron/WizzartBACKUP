using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFight : MonoBehaviour
{
    public enum Stage
    {
        Idel,
        Movment,
        Stage_1,
        Stage_2,
        Stage_3,
        Stage_4,
        Dead,
    }

    public Stage stage;

    public List<Transform> spawnPositionList = new List<Transform>();
    public List<GameObject> cloneSpawnList = new List<GameObject>();
    List<GameObject> prefabList = new List<GameObject>();
    List<GameObject> enemySpawnList = new List<GameObject>();
    
    public GameObject paintEnemy1;
    public GameObject paintEnemy2;
    public GameObject Mono;
    
    int spawnEnemycounter;
    int maxEnemy = 15;
    private float nextSpawn;
    public float spawnRate;
   
    public PaintCircleSpawn paintCircleSpawn;
    public MonoClones monoClones;
    public MonoShoot monoShoot;
    public delegate void ShootDelegate();
    public ShootDelegate shootDelagate;

    Vector3 cameraOrgPos;
    public Transform camera2;

    private void Start()
    {
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);

        stage = Stage.Idel;
        StartBattle();

        shootDelagate += monoShoot.MonoShoots;
    }

    private void Update()
    {
        if (stage == Stage.Idel) //TODO SWITHC
        {

            shootDelagate?.Invoke();
        }

        if (stage == Stage.Stage_1)
        {
            SpawnEnemy();
            shootDelagate?.Invoke();
        }

        if (stage == Stage.Stage_2)
        {
            paintCircleSpawn.StartSpawningBlobs();
            SpawnEnemy();
        }

        if (stage == Stage.Stage_3)
        {           
            paintCircleSpawn.StopSpawningBlobs();

            monoClones.MonoClone();
            shootDelagate?.Invoke();
            DestroyAllSpawnEnemy();
        }

        if (stage == Stage.Stage_4)
        {
           DestroyAllClone();           
           shootDelagate?.Invoke();    
        }

        if (stage == Stage.Dead || Input.GetMouseButtonDown(1))
        {
            DestroyAllSpawnEnemy();

            Time.timeScale = 0;
            cameraOrgPos = camera2.transform.position;
            Vector3 targetPos = Mono.transform.position;
            targetPos.z = cameraOrgPos.z;
            camera2.transform.DOMove(targetPos, 1).SetUpdate(true);
            camera2.transform.DOMove(cameraOrgPos, 1).SetDelay(2).SetUpdate(true).OnComplete(Reset);
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

    private void DestroyAllSpawnEnemy()
    {
        foreach (GameObject enemySpawn in enemySpawnList)
        {
            Destroy(GameObject.FindWithTag("PaintEnemy"));
        }
    }

    private void DestroyAllClone()
    {
        foreach (GameObject monoClones in cloneSpawnList)
        {
            Destroy(GameObject.FindWithTag("MonoClone"));
        }
    }

    private void Reset()
    {
         Time.timeScale = 1;
    }


}

