using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{
    Vector3 cameraOrgPos;
    public Transform camera2;
    public void CameraMoveTo(GameObject goToObject)
    {

        Time.timeScale = 0;
        cameraOrgPos = camera2.transform.position;
        Vector3 targetPos = goToObject.transform.position;
        targetPos.z = cameraOrgPos.z;
        camera2.transform.DOMove(targetPos, 1).SetUpdate(true);

        StartCoroutine("Explosion" );

        camera2.transform.DOMove(cameraOrgPos, 1).SetDelay(2).SetUpdate(true).OnComplete(Reset);

    }

    //public IEnumerator Explosion(GameObject crash, GameObject crashPlace, SpriteRenderer spriteRenderer )
    //{
    //    yield return new WaitForSecondsRealtime(1f);
    //    GameObject boomClone = Instantiate(Crash, CrashPlace.transform.position, Quaternion.identity);
    //    StartCoroutine(cameraShake.Shake(.25f, .8f));

    //    GetComponent<SpriteRenderer>().sprite = cage_4;
    //    Destroy(boomClone, 1);

    //}


    private void Reset()
    {

        Time.timeScale = 1;
    }
}
