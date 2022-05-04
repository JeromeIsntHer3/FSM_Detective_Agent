using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Cover State is to act as a form of "cover in combat"
//while the detective is moving closer to the enemies to engage them

public class CoverSubState : Combat
{
    public CoverSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Cover State");
        //set combatOccur to true to have different endings in the Over State
        combatOccur = true;
        //make sure combat has yet to start then set it and enemy attacking to true
        //so that this dialogue won't show up again
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
        //check to see if the enemy is attack to see if the detective can move 
        //forward to the next cover or not
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

    //Once the detective has made it close enough to the enemies
    //pressing z will transition to the Attack state to fight back
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