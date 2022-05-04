using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Over State act as the "Ending" state

public class InvestigationOver : BaseState
{
    public InvestigationOver(FSM _fsm)
    {
        fsm = _fsm;
    }

    public override void EnterState() {
        Debug.Log("Entered Over State");
    }
    public override void UpdateState()
    {
        //if combat has occured give a different line of dialogue
        if (combatOccur)
        {
            Debug.Log("DETECTIVE_INVESTIGATION_OVER_STATE: 'Welp, that was something alright!' Thanks for your help, go home and get rested!");
        }
        else
        {
            Debug.Log("DETECTIVE_NON_COMBAT_ANALYSIS_STATE: 'Hmm, well that seem about right. I'll look more into. Thanks for your help.'");
        }
    }
    public override void Exit() { }
}