using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    //create reference to each state object to be used in the FSM
    public AnalysisSubState analysisState;
    public AttackSubState attackState;
    public ClueSubState clueState;
    public CoverSubState coverState;
    public ExploreSubState exploreState;
    public IdleSubState idleState;
    public InjuredSubState injuredState;
    public MoveSubState moveState;
    public InvestigationOver overState;
    BaseState currState;

    void Start()
    {
        //create an instance of each state as an object

        //Non-Combat States
        analysisState = new AnalysisSubState(this);
        exploreState = new ExploreSubState(this);
        clueState = new ClueSubState(this);
        idleState = new IdleSubState(this);

        //Combat States
        attackState = new AttackSubState(this);
        coverState = new CoverSubState(this);
        injuredState = new InjuredSubState(this);
        moveState = new MoveSubState(this);

        //Investigation State
        overState = new InvestigationOver(this);
        currState = idleState;
        currState.EnterState();
    }

    void Update()
    {
        currState.UpdateState();
    }

    public void ChangeState(BaseState nextState)
    {
        currState.Exit();
        currState = nextState;
        currState.EnterState();
    }
}