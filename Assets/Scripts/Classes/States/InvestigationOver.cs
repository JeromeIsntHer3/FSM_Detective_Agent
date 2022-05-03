using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationOver : BaseState
{
    public InvestigationOver(FSM _fsm)
    {
        fsm = _fsm;
    }

    public override void EnterState() {
        Debug.Log("Entered Over State");
    }
    public override void UpdateState() { }
    public override void Exit() { }
}
