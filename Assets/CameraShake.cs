using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{  
    public IEnumerator Shake(float duration, float magnitut)
    {      
        
        Vector3 originalPos = transform.localPosition;
        float elaped = 0.0f;

        while (elaped < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitut;
            float y = Random.Range(-1f, 1f) * magnitut;

            transform.localPosition = new Vector3 (x, y, originalPos.z);

            elaped += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }
}
