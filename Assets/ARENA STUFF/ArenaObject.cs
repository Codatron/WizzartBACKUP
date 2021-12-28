using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script is attached to all objects inside an arena. (walls, trashcans etc etc etc)
This script used LeanTween to shrink and enlarge the object to give an illusion of them magically "popping" in and out
of existance. The particle system further amplifies this effect (but it needs some more "fun" particles ofcourse)
 */

public class ArenaObject : MonoBehaviour
{

    private ParticleSystem sys;
    public bool dontUseParticleSystem; // maybe we want some object to just show up without particles (assigned from inspector)


    public void SetMyParticleSystem(ParticleSystem _sys)
    {
        sys = _sys;
    }

    public void Enter()
    {
        transform.localScale = Vector3.zero;
        float delay = Random.Range(0.01f, 0.3f);
        LeanTween.scale(gameObject, Vector3.one, Random.Range(0.3f, 0.6f)).setDelay(delay).setEaseInBack();
        Invoke("SpawnParticles", delay + 0.35f);
    }

    public void SpawnParticles()
    {
        if (dontUseParticleSystem) return; // dont do any particle stuff

        if (sys != null)
        {
            sys.transform.position = transform.position;
            sys.Emit(13);
        }
    }

    private void End()
    {
        SpawnParticles();
        gameObject.SetActive(false);
    }



    public void Exit()
    {
        float delay = Random.Range(0.2f, 0.5f);
        LeanTween.scale(gameObject, Vector3.zero, Random.Range(0.1f, 0.25f)).setDelay(delay).setEaseLinear().setOnComplete(End);
    }

}
