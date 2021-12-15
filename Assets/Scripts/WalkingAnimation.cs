using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum StepType { None, Player, zero, one, two, three, four, five };
// this script moves a character back and forth to simulate movement (lol)

public class WalkingAnimation : MonoBehaviour
{

    public StepType stepType;

    public Rigidbody2D rigi;

    private float rotationTimer;
    private float rotationSine;
    private float bobbingTimer;
    private float bobbingSine;

    bool walking;

    public float speed;

    public float rotationAngle;
    public float bobbingHeight;

    public Vector3 localLerpPos;
    public Vector3 prevPos;

    public bool readyForTouch;

    //public ParticleSystem fartDust;

    private void Start()
    {
        rotationTimer = Random.value * 3.14f;
        speed = speed * Random.Range(0.9f, 1.1f);
    }

    void FixedUpdate()
    {
        walking = rigi.velocity != Vector2.zero;
        transform.localRotation = Quaternion.identity;
        localLerpPos = Vector3.zero;

        if (walking)
        {
            rotationTimer += Time.fixedDeltaTime * speed;
            bobbingTimer += Time.fixedDeltaTime;
            bobbingSine = Mathf.Sin(bobbingTimer * speed * 2);
            rotationSine = Mathf.Sin(rotationTimer + 0.5f);
            transform.localRotation = Quaternion.Euler(Vector3.forward * rotationSine * rotationAngle);
            localLerpPos = (Vector3.up * bobbingHeight) * (bobbingSine + 1f);

            if (readyForTouch)
            {
                if (bobbingSine < -0.9f)
                {
                    readyForTouch = false;
                    //fartDust.Emit(1);
                }
            }
            else
            {
                if (bobbingSine > 0)
                {
                    readyForTouch = true;
                }
            }
        }
        else
        {
            localLerpPos = Vector3.Lerp(localLerpPos, Vector3.zero, Time.fixedDeltaTime * 6);
            rotationTimer = 0;
            bobbingTimer = 0;
        }

        transform.localPosition = localLerpPos;
        prevPos = this.transform.position;
    }
}
