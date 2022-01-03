using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{
    public GameObject mono;
    public GameObject mStartPoint;
    void Start()
    {
        
    }

   public void StartMono()
    {
        Vector3 monoStartPoint = new Vector3(mStartPoint.transform.position.x, mStartPoint.transform.position.y);
        GameObject refMono = Instantiate(mono, monoStartPoint, Quaternion.identity);
    }
}
