using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Clue State is used as a way to have the detective collect
//clues and keep track of the clues

public class ClueSubState : NonCombat
{
    public ClueSubState(FSM _fsm)
    {
        fsm = _fsm;
    }

    public override void EnterState() {
        Debug.Log("Entered Clue State");
        Clues();
        //reset the time countdown
        currNoteTime = startNoteTime;
    }
    public override void UpdateState() {
        NotingClue();
        //check if the attack happens during the Clue state
        if (RandomAttack())
        {
            Debug.Log("DETECTIVE_NON_COMBAT_CLUE_STATE: Surprise Attack");
            fsm.ChangeState(fsm.coverState);
        }
    }
    public override void Exit() {
        Debug.Log("Exiting Clue State");
    }

    //Clues is used keep track of the amount of clues found
    void Clues()
    {
        currClues = cluesFound;
        cluesFound += 1;
        if (cluesFound > currClues)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_CLUE_STATE: 'Ah, a clue! Let me take note of this.'");
        }
    }

    //NotingClue is used as a timer for how long the detective
    //notes a clue down 
    void NotingClue()
    {
        currNoteTime -= 1 * Time.deltaTime;
        if (currNoteTime <= 0)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_CLUE_STATE: 'Alright, got it. Let's move on.'");
            fsm.ChangeState(fsm.exploreState);
        }
        Debug.Log(cluesFound);
    }
}