using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBlobHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PaintEnemy")|| other.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
