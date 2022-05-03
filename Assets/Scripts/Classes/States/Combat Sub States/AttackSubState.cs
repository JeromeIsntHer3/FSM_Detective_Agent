using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSubState : Combat
{
    public AttackSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Attack State");
    }
    public override void UpdateState() { }
    public override void Exit() { }
}
