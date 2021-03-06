using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PickUpBomb : MonoBehaviour
{
    public GameObject bombFactory;
    public GameObject dropBombPos;
    public GameObject factory_1;
    public GameObject boom;
    public GameObject dialogue;
    public Sprite factory_2;
    public Sprite factory_3;
    public GameObject clone;

    public GameObject boomPlace;

    public Transform camera2;
    public CameraShake cameraShake;

    public GameObject smoke_1;
    public GameObject smoke_2;
    public GameObject smokePlace;
    public GameObject smokePlace2;

    private BoolKeeper refBoolKeeper;
    public int bombCounter = 0;

    Vector3 cameraOrgPos;
    bool factoryBombTimes = true;

    public bool fixedCamera = false;

    public AudioClip clipFactoryExplosion;
    private AudioSource audioSource;

    public GameObject goToBossLevel;
    public GameObject goToBossLevelPlace;

    public bool allowed = false;

    SpawnLips spawnLips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GetComponent<SpriteRenderer>().enabled = false;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();

        spawnLips = FindObjectOfType<SpawnLips>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BombNoHands"))
        {
            if (allowed)
            {
               GetComponent<SpriteRenderer>().enabled = true;
               GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;

                Destroy(other.gameObject);

                allowed = false;
            }          
        }

        if (other.gameObject.CompareTag("Factory") && GetComponent<SpriteRenderer>().enabled == true) //TO DO BOX COLLIDER FoLJER INTE MED NAR MAN BYTER
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = true;
            clone = Instantiate(bombFactory, dropBombPos.transform.position, Quaternion.identity);

            bombExposition();

            refBoolKeeper.dontShoot = false;

            bombCounter++;
          
        }
    }
    private void bombExposition()
    {
        Destroy(clone, 2);

        Invoke(nameof(PlayExplosion), 2);
    }

    public void PlayExplosion()
    {
        Time.timeScale = 0;
        cameraOrgPos = camera2.transform.position;
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Factory").transform.position;
        targetPos.z = cameraOrgPos.z;
        camera2.transform.DOMove(targetPos, 1).SetUpdate(true);//1 sek aka dit

        StartCoroutine("Explosion");
        camera2.transform.DOMove(cameraOrgPos, 1).SetDelay(2).SetUpdate(true).OnComplete(Reset);//1 sek tillbaka 2sek som allt tog
    }
   public IEnumerator Explosion()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameObject boomClone = Instantiate(boom, boomPlace.transform.position, Quaternion.identity);
        StartCoroutine(cameraShake.Shake(.25f, .8f));
        GameManager.PlaySFXDirty(clipFactoryExplosion, 0.2f);
        Destroy(boomClone, 0.8f);

        if (bombCounter==1 && factoryBombTimes)
        {
            GameObject smallSmokeClone = Instantiate(smoke_1, smokePlace.transform.position, Quaternion.identity);
            GameObject smallSmokeClone2 = Instantiate(smoke_1, smokePlace2.transform.position, Quaternion.identity);
        }

        if (bombCounter==2 && factoryBombTimes)
        {
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_2;
            GameObject largeSmokeClone1 = Instantiate(smoke_1, smokePlace.transform.position, Quaternion.identity);
            GameObject largeSmokeClone2 = Instantiate(smoke_2, smokePlace2.transform.position, Quaternion.identity);
        }

        if (bombCounter == 3 && factoryBombTimes)
        {
            factory_1.GetComponent<SpriteRenderer>().sprite = factory_3;
            GameObject largeSmokeClone1 = Instantiate(smoke_2, smokePlace.transform.position, Quaternion.identity);
            GameObject largeSmokeClone2 = Instantiate(smoke_2, smokePlace2.transform.position, Quaternion.identity);
            factoryBombTimes = false;

            fixedCamera = true;

            Vector3 newLevelPlace = new Vector3(goToBossLevelPlace.transform.position.x, goToBossLevelPlace.transform.position.y);
            GameObject goToBoss = Instantiate(goToBossLevel, newLevelPlace, Quaternion.identity);
            StartCoroutine("goToBoss");
        }
    }

    private void Reset()
    {
        Time.timeScale = 1;
    }


    public IEnumerator goToBoss()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("BossScene");
        MusicSound.PlayBossMusic();

    }
}

