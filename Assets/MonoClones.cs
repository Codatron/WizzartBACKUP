using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoClones : MonoBehaviour
{
    public Transform[] clonePoints;
    public GameObject monoClone;
    bool cloning;
    public BossFight bossFight;

    public void MonoClone()

    {       
        if (cloning == false)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 spawnPosition = clonePoints[i].position;
                GameObject mClone = Instantiate(monoClone, spawnPosition, Quaternion.identity);
                mClone.GetComponent<MonoMovmentState>().movePoints = GetComponent<MonoMovmentState>().movePoints;
               bossFight.cloneSpawnList.Add(mClone);
            }

            cloning = true;
        }
    }      
}
