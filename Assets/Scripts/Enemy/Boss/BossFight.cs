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

    }

    public Stage stage;

    //TO DO LAGG IN TRIGGER FOR ATT STARTA 

    List<GameObject> prefabList = new List<GameObject>();
    List<Vector3> spawnPositionList = new List<Vector3>();

    public GameObject paintEnemy1;
    public GameObject paintEnemy2;

    int spawnEnemycounter;
    int maxEnemy = 10;

    void awake()
    {
        
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);

        foreach(Transform spawnPosition in transform.Find("SpawnPositions"))
        {
            spawnPositionList.Add(spawnPosition.position);
        }

        stage = Stage.WatingToStart;
    }


    private void startBattle()
    {
        stage = Stage.Stage_1;
        spawnEnemy();
        StartNextStage();
        //TODO LAGG IN KOD for hur ofta de ska spawn

    }

    private void spawnEnemy()
    {// random prefab + position

        if (spawnEnemycounter < maxEnemy)
        {
            Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)];
            int prebRandom= UnityEngine.Random.Range(0, 1);

            GameObject hitPrefab = Instantiate(prefabList[prebRandom], spawnPosition, Quaternion.identity);
            spawnEnemycounter++;
        } 
    }

    private void MonoTakingDamage()
    {
        switch (stage)
        {
            case Stage.Stage_1:

                if (GameObject.FindGameObjectWithTag("Mono").GetComponent<MonoHealth>().currentHealth < 70)
                {
                    Debug.Log("Stage1");
                    StartNextStage();
                }

                break;

            case Stage.Stage_2:
                if (GameObject.FindGameObjectWithTag("Mono").GetComponent<MonoHealth>().currentHealth < 30)
                {
                    Debug.Log("Stage2");
                    StartNextStage();
                }

                break;
        }

        if (GameObject.FindGameObjectWithTag("Mono").GetComponent<MonoHealth>().currentHealth <=0)
        {
            MonoisDead();
        }
    }

    public void StartNextStage()
    {
        switch(stage)
        {
            case Stage.WatingToStart:
                stage = Stage.Stage_1;
                break;
            case Stage.Stage_1:
                stage = Stage.Stage_2;
                break;
            case Stage.Stage_2:
                stage = Stage.Stage_3;
                break;
        }
    }

    private void MonoisDead()
    {
        Debug.Log("DÖD");
    }
}
