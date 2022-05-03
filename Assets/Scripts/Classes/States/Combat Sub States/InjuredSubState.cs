using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjuredSubState : Combat
{
    public InjuredSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Injured State");
    }
    public override void UpdateState() { }
    public override void Exit() { }
}
