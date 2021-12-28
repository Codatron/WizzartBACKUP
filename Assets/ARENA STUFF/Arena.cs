using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script holds a list of all objects that are "inside" the arena and acts as an inbetween between the manager and 
the individual objects. In contrast to the Arena objects this object is always "active" and is tasked with turning its
children on and off as well as calling relevant "Enter" and "Exit" functions on them.
*/

public class Arena : MonoBehaviour
{

    public List<ArenaObject> arenaObjects; // all objects inside the arena sorted into a list.

    public ParticleSystem sys; // the particlesystem used by all ArenaObjects

    private void Start()
    {
      //  arenaObjects = new List<ArenaObject>();
      //  arenaObjects.AddRange(GetComponentsInChildren<ArenaObject>());

        foreach (ArenaObject obj in arenaObjects) // turn off all arena objects as soon as the game loads.
        {
            if (sys != null) // <- just in case we forget to set it in the inspector (would otherwise result in an error)
            {
                obj.SetMyParticleSystem(sys); // give each arena object a reference to the particle system
            }
            obj.gameObject.SetActive(false);
        }

    }

    public void EnterMe() // activate all arena objects and call their enter function
    {
        foreach (ArenaObject obj in arenaObjects)
        {
            obj.gameObject.SetActive(true);
        }

        for (int i = 0; i < arenaObjects.Count; i++)
        {
            arenaObjects[i].Enter();
        }
    }


    public void ExitMe() // call each exit function. (the arenaobject will turn itself off inside its own script)
    {
        for (int i = 0; i < arenaObjects.Count; i++)
        {
            arenaObjects[i].Exit();
        }
    }
}
