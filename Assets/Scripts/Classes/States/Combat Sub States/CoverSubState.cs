using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSubState : Combat
{
    public CoverSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Cover State");
    }
    public override void UpdateState() { }
    public override void Exit() { }
}