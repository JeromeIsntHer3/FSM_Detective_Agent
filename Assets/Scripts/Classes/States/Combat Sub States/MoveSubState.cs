using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Move State is to act as a way for the detective to
//move from cover to cover to get closer to the enemies
//everytime they stop attacking

public class MoveSubState : Combat
{
    public MoveSubState(FSM _fsm)
    {
        fsm = _fsm;
    }

    public override void EnterState() {
        Debug.Log("Entered Move State");
        Debug.Log("DETECTIVE_COMBAT_MOVE_STATE: 'Come on! Keep moving!'");
        //decrease the dist between the detective and enemy
        distFromEnemy -= 1;
        Debug.Log(distFromEnemy);
    }

    public override void UpdateState() {
        EnemyAttacking();
        //if the enemies are attacking the detective will take cover
        //if not the detective will move on to the next cover
        if (enemyAttacking)
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

    //Set the enemy to attack so that the detective will take cover
    //during this period and will transition to the cover state
    void EnemyAttacking()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            enemyAttacking = true;
        }
    }
}