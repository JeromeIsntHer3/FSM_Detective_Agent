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

        combatOccur = true;
        //make sure combat has yet to start then set it and enemy attacking to true
        if (!combatStart)
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Damn, I guess they came back to finish what they started.'");
            combatStart = true;
            enemyAttacking = true;
        }
        else if(healed)
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Okay, let's get back into it.'");
        }
        else
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Okay, we are almost there.'");
        }
    }
    public override void UpdateState() {
        EnemyStopAttacking();
        AttackBack();
        if (enemyAttacking)
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

    //set the enemies to stop attacking, allowing the detective to move state
    void EnemyStopAttacking()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            enemyAttacking = false;
        }
    }

    //to allow the detective to transition into the attack state
    void AttackBack()
    {
        if(distFromEnemy <= enemyRange)
        {
            Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Okay, we're close enough'");
            if (Input.GetKeyDown(KeyCode.Z)){
                Debug.Log("DETECTIVE_COMBAT_COVER_STATE: 'Alright, my turn!");
                fsm.ChangeState(fsm.attackState);
            }
        }
    }
}