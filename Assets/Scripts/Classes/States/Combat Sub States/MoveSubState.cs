using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSubState : Combat
{
    public MoveSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Move State");
        Debug.Log("DETECTIVE_COMBAT_MOVE_STATE: 'Come on! Keep moving!'");
    }
    public override void UpdateState() {
        EnemyAttacking();
        if (attacking)
        {
            Debug.Log("DETECTIVE_COMBAT_MOVE_STATE: 'They're attacking again, get down!'");
            fsm.ChangeState(fsm.coverState);
        }
        else
        {
            Debug.Log("DETECTIVE_COMBAT_MOVE_STATE: 'Move! Move!'");
        }
    }
    public override void Exit() {
        Debug.Log("Exiting Move State");
    }

    void EnemyAttacking()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            attacking = true;
        }
    }
}