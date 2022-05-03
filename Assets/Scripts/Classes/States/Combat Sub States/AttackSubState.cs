using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSubState : Combat
{
    public override void EnterState() {
        Debug.Log("Entered Attack State");
    }
    public override void UpdateState() { }
    public override void Exit() { }
}
