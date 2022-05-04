using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Idle State is the "Starting" state of the detective
//he will, wait for the player to be near enough and then
//transition to the explore state. If the player moves away
//he will return to the idle state

public class IdleSubState : NonCombat
{
    public IdleSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() 
    {
        Debug.Log("Entered Idle State");
        //Show this dialogue for the detective if they havent met yet
        if (!metUp)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_IDLE_STATE: 'Where is the rookie?'");
        }
    }
    public override void UpdateState() 
    {
        //Show this dialogue if this is the first time the detective and player meet
        if (CheckPlayerNearby() && !metUp)
        {
            Debug.Log("DETECTIVE_NON_COMBAT_IDLE_STATE: 'Ah, there you are! Come on follow me and let's see what you can learn.'");
            fsm.ChangeState(fsm.exploreState);
        }
        //If the player left the detective and came back play this dialogue
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

    //To check if the detective will be in explore or idle
    bool CheckPlayerNearby()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
}