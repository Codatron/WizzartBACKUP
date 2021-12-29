using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoClones : MonoBehaviour
{
    public Transform[] clonePoints;
    public GameObject monoClone;
    public BoolKeeper refBoolKeeper;

    public void MonoClone()

    {
        if (refBoolKeeper.cloneing == false)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector3 spawnPosition = clonePoints[i].position;
                GameObject mClone = Instantiate(monoClone, spawnPosition, Quaternion.identity);

                mClone.AddComponent<MonoHealth>().currentHealth = 50;
                mClone.AddComponent<MonoShoot>();
                mClone.AddComponent<MonoMovmentState>();


            }

            refBoolKeeper.cloneing = true;
        }
    }
       
}
