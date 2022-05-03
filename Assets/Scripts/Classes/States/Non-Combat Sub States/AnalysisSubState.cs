using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalysisSubState : NonCombat
{
    public AnalysisSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Analysis State");
        //have the detective ask the player what they think 
        Debug.Log("DETECTIVE_NON_COMBAT_ANALYSIS_STATE: 'So, what do you think happened?'");
        Debug.Log("DETECTIVE_NON_COMBAT_ANALYSIS_STATE: Press 1 for 'Murder'");
        Debug.Log("DETECTIVE_NON_COMBAT_ANALYSIS_STATE: Press 2 for 'Suicide'");
        Debug.Log("DETECTIVE_NON_COMBAT_ANALYSIS_STATE: Press 3 for 'Coincidental Assault'");
    }
    public override void UpdateState() {
        AnalyseClues();
        //check if the attack happens during the analysis state
        if (RandomAttack())
        {
            fsm.ChangeState(fsm.coverState);
        }
    }
    public override void Exit() { 
        Debug.Log("Exiting Analysis State");
    }

    //pseudo way to let the player react to being asked
    void AnalyseClues()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            fsm.ChangeState(fsm.overState);
        }
    }
}