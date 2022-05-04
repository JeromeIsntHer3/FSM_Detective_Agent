using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Attack State allows the detective to attack the enemies
//However, there is a chance everytime he takes where he may
//be injured which will transition into the injured state

public class AttackSubState : Combat
{
    public AttackSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Attack State");
    }
    public override void UpdateState() {
        //check if the detective attack and if so, eliminate one enemy
        if (AttackEnemy())
        {
            enemyCount -= 1;
            Debug.Log("DETECTIVE_COMBAT_ATTACK_STATE: Attacking Enemy");
            Debug.Log(enemyCount);
            //check if the enemies hits the detective as he his attacking them
            if (EnemyAttack())
            {
                Debug.Log("DETECTIVE_COMBAT_ATTACK_STATE: 'Ah, I've been hit!'");
                fsm.ChangeState(fsm.injuredState);
            }
        }
        EnemiesDead();
    }
    public override void Exit() {
        Debug.Log("Exiting Attack State");
    }

    //Allow the detective to attack the enemies (This version is input to allow for better use of the FSM)
    bool AttackEnemy()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    //Randomise the chance for the enemy to attack
    bool EnemyAttack()
    {
        if (Random.Range(0, 10) >= 8)
        {
            return true;
        }
        return false;
    }

    //Once all enemies are dead, transition over to the Over State
    void EnemiesDead()
    {
        if (enemyCount <= 0)
        {
            Debug.Log("DETECTIVE_COMBAT_ATTACK_STATE: All enemies are dead");
            fsm.ChangeState(fsm.overState);
        }
    }
}
