using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSubState : NonCombat
{
    public IdleSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() 
    {
        Debug.Log("Entered Idle State");
    }
    public override void UpdateState() 
    {
        if (CheckPlayerNearby() && !metUp)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_IDLE_STATE: 'Ah, there you are! Come on follow me and let's see what you can learn.'");
            fsm.ChangeState(fsm.exploreState);
        }
        else if (!metUp)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_IDLE_STATE: 'Where is the rookie?'");
        }
        if(CheckPlayerNearby() && metUp)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_IDLE_STATE: 'Where did you go? Nevermind, let's just continue with the investigation.'");
            fsm.ChangeState(fsm.exploreState);
        }
        if (RandomAttack() && metUp)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_IDLE_STATE: Surprise Attack");
            fsm.ChangeState(fsm.coverState);
        }
    }
    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }

    bool CheckPlayerNearby()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
}