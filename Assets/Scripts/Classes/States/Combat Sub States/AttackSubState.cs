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
    public override void UpdateState() {
        if (AttackEnemy())
        {
            enemyCount -= 1;
            Debug.Log("DETECTIVE_COMBAT_ATTACK_STATE: Attacking Enemy");
            Debug.Log(enemyCount);
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

    bool AttackEnemy()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    bool EnemyAttack()
    {
        if (Random.Range(0, 10) >= 8)
        {
            return true;
        }
        return false;
    }
    void EnemiesDead()
    {
        if (enemyCount <= 0)
        {
            Debug.Log("DETECTIVE_COMBAT_ATTACK_STATE: All enemies are dead");
            fsm.ChangeState(fsm.overState);
        }
    }
}
