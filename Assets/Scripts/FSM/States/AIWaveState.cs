using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveState : AIState
{
	

	public AIWaveState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AISadState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0.1f));
		transition.AddCondition(new BoolCondition(agent.isHappy, false));
		transitions.Add(transition);
	}

	public override void OnEnter()
	{
		Debug.Log("Wave");
		agent.timer.value = 5;

		agent.movement.Stop();
		agent.movement.Velocity = Vector3.zero;

		agent.isWaving.value = true;
		agent.animator?.SetBool("Wave", true);
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
		agent.animator?.SetBool("Wave", false);
		agent.isWaving.value = false;
	}
}
