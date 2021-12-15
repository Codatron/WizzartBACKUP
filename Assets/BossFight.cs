using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    //TO DO LAGG IN TRIGGER FOR ATT STARTA 

    List<GameObject> prefabList = new List<GameObject>();
    List<Vector3> spawnPositionList = new List<Vector3>();

    public GameObject paintEnemy1;
    public GameObject paintEnemy2;

    void awake()
    {
        
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);

        foreach(Transform spawnPosition in transform.Find("SpawnPositions"))
        {
            spawnPositionList.Add(spawnPosition.position);
        }
    }

   
    void Update()
    {
        spawnEnemy();
    }

    private void startBattle()
    {


    }

    private void spawnEnemy()
    {// random prefab + position
        Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)];
        int prebRandom= UnityEngine.Random.Range(0, 1);

        GameObject hitPrefab = Instantiate(prefabList[prebRandom], spawnPosition, Quaternion.identity);

    }
}
