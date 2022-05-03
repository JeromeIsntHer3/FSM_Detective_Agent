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
        Debug.Log("DETECTIVE_NON_COMBAT_CLUE_STATE: 'So, what do you think happened?'");
        Debug.Log("Press 1 for 'Murder'");
        Debug.Log("Press 2 for 'Suicide'");
        Debug.Log("Press 3 for 'Coincidental Assault'");
    }
    public override void UpdateState() {
        AnalyseClues();
        if (RandomAttack())
        {
            Debug.Log("Surprise Attack");
            fsm.ChangeState(fsm.coverState);
        }
    }
    public override void Exit() { 
        Debug.Log("Exiting Analysis State");
    }

    void AnalyseClues()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Hmm, well that seem about right. I'll look more into. Thanks for your help.");
            fsm.ChangeState(fsm.overState);
        }
    }
}