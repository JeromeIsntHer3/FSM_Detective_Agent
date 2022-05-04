using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Injured State is used when the detective gets injured while
//fighting the enemies, which forces the detective to take cover

public class InjuredSubState : Combat
{
    public InjuredSubState(FSM _fsm)
    {
        fsm = _fsm;
    }
    public override void EnterState() {
        Debug.Log("Entered Injured State");
    }
    public override void UpdateState() {
        if (Heal())
        {
            healed = true;
            //Debug.Log("DETECTIVE_COMBAT_INJURED_STATE: 'Ah, thank you! Now let's get back into the fight!'");
            fsm.ChangeState(fsm.coverState);
        }
    }
    public override void Exit() {
        Debug.Log("Exiting Injured State");
    }

    //Allow the detective to be healed
    bool Heal()
    {
        return Input.GetKeyDown(KeyCode.H);
    }
}