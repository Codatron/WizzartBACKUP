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

    public Sine sineHorizontal;
    public Sine sineVertical;
    public bool isOnPatrol;
    public bool isOverSineMidHorizontal;
    public bool isOverSineMidVertical;
    public float sineMagRightHalf;
    public float sineMagUpHalf;

    private Vector3 startPos;
    private EnemyAIPathfind enemyAIPathfindScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyAIPathfindScript = GetComponent<EnemyAIPathfind>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Sine sineWave = new Sine();
        
        sineHorizontal.Tick();
        sineVertical.Tick();

        transform.position = startPos + (Vector3.right * sineHorizontal.sine) + (Vector3.up * sineVertical.sine);

        isOnPatrol = true;

        if (sineVertical.sine > 0.0f)
        {
            isOverSineMidVertical = true;
        }
        else if (sineVertical.sine <= -0.1f)
        {
            isOverSineMidVertical = false;
        }

        if (enemyAIPathfindScript.isTargetWithinRange)
        {
            isOnPatrol = false;
            Destroy(this);
        }
    }
}

