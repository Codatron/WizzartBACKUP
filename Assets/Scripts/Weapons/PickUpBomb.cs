using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using DG.Tweening;

public class PickUpBomb : MonoBehaviour
{
    public GameObject bombFactory;
    public GameObject dropBombPos;
    public GameObject factory_1;
    public GameObject boom;
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

    public StartBossFight startBossFight;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject g = GameObject.FindGameObjectWithTag("BoolKeeper");
        refBoolKeeper = g.GetComponent<BoolKeeper>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BombNoHands"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;

            Destroy(other.gameObject);
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

            startBossFight.StartMono();
        }
    }

    private void Reset()
    {
        Time.timeScale = 1;
    }


    //TO DO SLICA OM FABRIKEN SÅ DE HAR SAMMA STORLEK.
}

