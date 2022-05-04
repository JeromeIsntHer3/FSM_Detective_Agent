using UnityEngine;

//Base State/Superclass is what the states will derive from in order to be part of FSM

//This class will not be instantiated and will
//only be used for the concrete states to derive from

public abstract class BaseState
{
    //to check if combat has occured
    public static bool combatOccur;


    //public bool combat = false;
    protected FSM fsm;
    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void Exit() { }

}