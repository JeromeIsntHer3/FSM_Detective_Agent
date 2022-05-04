using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Explore State allow the detective to search for clues

public class ExploreSubState : NonCombat
{
    public ExploreSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() 
    {
        Debug.Log("Entered Explore State");
        Debug.Log("DETECTIVE_NON_COMBAT_EXPLORE_STATE: 'Let's see what we can find...' ");
    }
    public override void UpdateState() {
        //change the metUp to be true to show that the player and detective have alr met
        metUp = true;
        AllCluesFound();
        Debug.Log(cluesFound);
        if (ClueFound())
        {
            Debug.Log("DETECTIVE_NON_COMBAT_EXPLORE_STATE: 'Hmm, what's this?' ");
            fsm.ChangeState(fsm.clueState);
        }
        else
        {
            Debug.Log("DETECTIVE_NON_COMBAT_EXPLORE_STATE: 'Nothing here, let's move on.' ");
        }
        if (CheckPlayerAway())
        {
            Debug.Log("DETECTIVE_NON_COMBAT_EXPLORE_STATE: 'Hey! Where are you going?' ");
            fsm.ChangeState(fsm.idleState);
        }
        if (RandomAttack())
        {
            Debug.Log("DETECTIVE_NON_COMBAT_EXPLORE_STATE: Surprise Attack");
            fsm.ChangeState(fsm.coverState);
        }
    }
    public override void Exit() {
        Debug.Log("Exiting Explore State");
    }

    //Act as a button to show the detective finding a clue to have more control over the state machine
    bool ClueFound()
    {
        //if(Random.Range(0,10)>= 9)
        //{
        //    return true;
        //}
        //return false;
        return Input.GetKeyDown(KeyCode.C);
    }

    //Act as a way to show the player moving away from detective
    bool CheckPlayerAway()
    {
        return Input.GetKeyDown(KeyCode.W);
    }

    //When all clues have been found, transition to analysis state
    void AllCluesFound()
    {
        if (cluesFound >= totalClues)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_EXPLORE_STATE: 'Welp, that should be all the clues let's get back to the van and consolidate what we found.'");
            fsm.ChangeState(fsm.analysisState);
        }
    }
}