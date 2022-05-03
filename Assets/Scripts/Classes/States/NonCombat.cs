using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Non-Combat concrete state is here to keep variables that the
//sub states will use such as the clues required to move onto
//combat section and the time to search for clues
public abstract class NonCombat : BaseState
{
    //track the clues that have been found
    public static int cluesFound = 0;

    //the total clues needed to move on to analysis
    public static int totalClues = 10;

    //set a seperate value to check that clues found have increased
    public static int currClues;

    //set the amount of noting time needed in runtime
    public float currNoteTime = 0f;

    //the amount of noting time needed
    public float startNoteTime = 3f;

    //check if the player and detective have already met up
    public static bool metUp = false;

    //the surprise attack by the bad guys
    public static bool RandomAttack()
    {
        //if (Random.Range(0, 100) >= 99)
        //{
        //    return true;
        //}
        //return false;
        return Input.GetKeyDown(KeyCode.A);
    }
}