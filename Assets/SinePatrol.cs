using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinePatrol : MonoBehaviour
{
    [System.Serializable]
    public class Sine 
    { 
        public float sineSpeed;
        public float sineMag;
        public float sine;
        public float timer;

        public void Tick()
        {
            timer += Time.deltaTime * sineSpeed;
            sine = Mathf.Sin(timer) * sineMag;
        }
    }

    public Sine sineX;
    public Sine sineY;
    public bool isOnPatrol;
    public bool isOverSineMidX;
    public bool isOverSineMidY;
    public float sineMagHalfX;
    public float sineMagHalfY;

    private Vector3 startPos;
    private EnemyAIPathfind enemyAIPathfindScript;

    
    void Start()
    {
        enemyAIPathfindScript = GetComponent<EnemyAIPathfind>();
        startPos = transform.position;
    }

   
    void Update()
    {
        //Sine sineWave = new Sine();

        sineX.Tick();
        sineY.Tick();

        transform.position = startPos + (Vector3.right * sineX.sine) + (Vector3.up * sineY.sine);

        isOnPatrol = true;
        CrossSineMidX();
        CrossSineMidY();
        KillScriptWithinRange();
    }

    private void KillScriptWithinRange()
    {
        if (enemyAIPathfindScript.isTargetWithinRange)
        {
            isOnPatrol = false;
            Destroy(this);
        }
    }

    private void CrossSineMidY()
    {
        if (sineX.sine > 0.0f)
        {
            isOverSineMidY = true;
        }
        else if (sineX.sine <= -0.1f)
        {
            isOverSineMidY = false;
        }
    }

    private void CrossSineMidX()
    {
        if (sineY.sine > 0.0f)
        {
            isOverSineMidX = true;
        }
        else if (sineY.sine <= -0.1f)
        {
            isOverSineMidX = false;
        }
    }
}

