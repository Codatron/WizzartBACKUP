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
    public bool isPositiveSineX;
    public bool isPositiveSineY;

    private Vector3 startPos;
    private EnemyAIPathfind enemyAIPathfindScript;
    
    void Start()
    {
        enemyAIPathfindScript = GetComponent<EnemyAIPathfind>();
        startPos = transform.position;
    }
   
    void Update()
    {
        sineX.Tick();
        sineY.Tick();

        transform.position = startPos + (Vector3.right * sineX.sine) + (Vector3.up * sineY.sine);

        isOnPatrol = true;
        SineXPositiveAmplitude();
        SineYPositiveAmplitude();
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

    private void SineYPositiveAmplitude()
    {
        if (sineX.sine > 0.0f)
        {
            isPositiveSineY = true;
        }
        else if (sineX.sine <= -0.1f)
        {
            isPositiveSineY = false;
        }
    }

    private void SineXPositiveAmplitude()
    {
        if (sineY.sine > 0.0f)
        {
            isPositiveSineX = true;
        }
        else if (sineY.sine <= -0.1f)
        {
            isPositiveSineX = false;
        }
    }
}

