using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{
    Vector3 cameraOrgPos;
    public Transform camera2;

    public CameraShake cameraShake;
    public GameObject Crash;
    public GameObject CrashPlace;
    public CageHealth cageHealth;
    PlayerController playerController;
    public GameObject startDialogCage;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void CameraMoveTo(GameObject goToObject)
    {

        Time.timeScale = 0;
        cameraOrgPos = camera2.transform.position;
        Vector3 targetPos = goToObject.transform.position;
        targetPos.z = cameraOrgPos.z;
        camera2.transform.DOMove(targetPos, 1).SetUpdate(true);

        StartCoroutine("Explosion" );
        playerController.StartDialog(startDialogCage);

        camera2.transform.DOMove(cameraOrgPos, 1).SetDelay(2).SetUpdate(true).OnComplete(Reset);
    }

    public IEnumerator Explosion()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameObject boomClone = Instantiate(Crash, CrashPlace.transform.position, Quaternion.identity);
        StartCoroutine(cameraShake.Shake(.25f, .8f));

        cageHealth.spriteRend++;

        Destroy(boomClone, 0.5f);
    }

    private void Reset()
    {
        Time.timeScale = 1;
    }
}
