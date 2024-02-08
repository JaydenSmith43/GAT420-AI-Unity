using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();

    public AIState CurrentState { get; private set; } = null;

    public void Update()
    {
        CurrentState?.OnUpdate();
    }

    public void AddState(string name, AIState state)
    {
        Debug.Assert(!states.ContainsKey(name), "State machine already contains state " + name); //assert if we dont have this state by name

        states[name] = state;
    }

    public void SetState(string name)
    {
		Debug.Assert(states.ContainsKey(name), "State machine does not contain state " + name); //assert if we do have this state by name

        AIState nextState = states[name];

        if (nextState == CurrentState) return; //do re-enter state

        CurrentState?.OnExit(); //exit current
        CurrentState = nextState; //set next state
        CurrentState?.OnEnter(); //enter new state
	}
}
