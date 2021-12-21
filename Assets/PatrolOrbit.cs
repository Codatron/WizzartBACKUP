using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolOrbit : MonoBehaviour
{
    public GameObject objectToOrbit;
    public float orbitSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(objectToOrbit.transform.position, Vector3.right, orbitSpeed * Time.deltaTime);
    }
}
