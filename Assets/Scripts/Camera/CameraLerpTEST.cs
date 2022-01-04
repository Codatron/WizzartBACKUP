using UnityEngine;

public class CameraLerpTEST : MonoBehaviour
{
    public Transform target;
    public Vector3 camOffset;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    
    [Range(0, 1)]
    public float smoothingValue;

    PickUpBomb refPickUpBomb;
   
    private void Start()
    {
        Camera camera = Camera.main;
        minX += camera.orthographicSize * camera.aspect;
        minY += camera.orthographicSize;
        maxX -= camera.orthographicSize * camera.aspect;
        maxY -= camera.orthographicSize;

        transform.position = target.position;

        refPickUpBomb = GameObject.FindGameObjectWithTag("BombHands").GetComponent<PickUpBomb>();
    }

    private void FixedUpdate()
    {
        FollowTarget();

        CamStayInBoundaries();
    }

    private void Update()
    {
        if (refPickUpBomb.fixedCamera==true)
        {
           
        }
    }

    private void FollowTarget()
    {
        if (target==null)
        {
            return;
        }

        Vector3 targetPos = target.position + camOffset;
        Vector3 camSmoothPos = Vector3.Lerp(transform.position, targetPos, smoothingValue);
        transform.position = camSmoothPos;


    }
    //TODO: Camera follows ahead of player after completing LERP?

    private void CamStayInBoundaries()
    {
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, camOffset.z);
        }

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, camOffset.z);
        }

        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, camOffset.z);
        }

        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, camOffset.z);
        }
    }
}
