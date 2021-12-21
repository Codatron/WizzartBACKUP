using UnityEngine;

public class CameraLerpTEST : MonoBehaviour
{
    public Transform target;
    public Vector3 camOffset;
    
    [Range(0, 1)]
    public float smoothingValue;

    private void Start()
    {
        transform.position = target.position;   
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPos = target.position + camOffset;
        Vector3 camSmoothePos = Vector3.Lerp(transform.position, targetPos, smoothingValue);
        transform.position = camSmoothePos;
    }
    //TODO: Camera follows ahead of player after completing LERP?
}
