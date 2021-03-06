using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

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

   public MonoMovmentState monoMovmentState;

    public AudioClip monoLaugh;
    private AudioSource speaker;

    bool playSound;
  
     
    private void Start()
    {
        prefabList.Add(paintEnemy1);
        prefabList.Add(paintEnemy2);
    

        stage = Stage.Idel;
        StartBattle();

        shootDelagate += monoShoot.MonoShoots;

        speaker = GetComponent<AudioSource>();

        playSound = false;


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

            if (!playSound)
            {
                speaker.PlayOneShot(monoLaugh);
                playSound = true;
            }
        }

        if (stage == Stage.Stage_2)
        {
            paintCircleSpawn.StartSpawningBlobs();
            SpawnEnemy();

            if (playSound)
            {
                speaker.PlayOneShot(monoLaugh);
                playSound = false;
            }
        }

        if (stage == Stage.Stage_3)
        {           
            paintCircleSpawn.StopSpawningBlobs();

            monoClones.MonoClone();
            shootDelagate?.Invoke();
            DestroyAllSpawnEnemy();

            if (!playSound)
            {
                speaker.PlayOneShot(monoLaugh);
                playSound = true;
            }
        }

        if (stage == Stage.Stage_4)
        {
            SpawnEnemy();
            DestroyAllClone();           
            shootDelagate?.Invoke();

            if (playSound)
            {
                speaker.PlayOneShot(monoLaugh);
                playSound = false;
            }
        }

        if (stage == Stage.Dead)
        {
            gameObject.GetComponent<Animator>().Play("Death");
            monoMovmentState.speed = 0;
            DestroyAllSpawnEnemy();
            StartCoroutine(goBack());
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

    IEnumerator goBack()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneBuildIndex: 4);
        MusicSound.PlayMenuMusic();
    }
}

