using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls the "signal" that gets sent out to all relevant arenas.
This should be the only script that another script (like the boss.cs) would need to look at in order to perform
all relevant functionalities.
*/
public class ArenaManager : MonoBehaviour
{
    public List<Arena> arenas; // a list of all the parent objects with an attached Arena.cs script to it
    public int currentArenaIndex; // the currently active arena (index refers to its position in the list)

    void Start()
    {
        currentArenaIndex = -1; // the game doesn't start in an arena, so we set the index to "-1" to signify that.
    }

    void Update() // these are dev-buttons to help us test the swapping of arenas.
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnterArena(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnterArena(1);
        }
    }

    public void EnterArena(int newArenaIndex) // a public function that other scripts can access to change the current arena
    {
        StartCoroutine(DoArenaChange(newArenaIndex));
    }

    private IEnumerator DoArenaChange(int newIndex) // a coroutine that pauses after the current arena exits and then enters the new one
    {
        if (currentArenaIndex != -1) // this value is only "-1" the first time we enter a new arena.
        {
            arenas[currentArenaIndex].ExitMe();
            yield return new WaitForSeconds(1.75f);
        }

        currentArenaIndex = newIndex;

        arenas[currentArenaIndex].EnterMe();
    }
}
