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
        if (!combatStart)
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Damn, I guess they came back to finish what they started.'");
            combatStart = true;
            attacking = true;
        }
        else
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Okay, we are almost there.'");
        }
    }
    public override void UpdateState() {
        EnemyStopAttacking();
        if (attacking)
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Get down! Wait until they stop shooting!");
            
        }
        else 
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Okay, let's move!");
            fsm.ChangeState(fsm.moveState);
        }
    }
    public override void Exit() {
        Debug.Log("Exiting Cover State");
    }
    void EnemyStopAttacking()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            attacking = false;
        }
    }
}