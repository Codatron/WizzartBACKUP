using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceMouse : MonoBehaviour
{
    private Camera cam;
    private float angle;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
