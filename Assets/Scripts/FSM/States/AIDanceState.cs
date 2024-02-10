using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDanceState : AIState
{
	

	public AIDanceState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);

		//var condition = new FloatCondition(agent.timer, Condition.Predicate.LESS, 0);
		//condition.IsTrue();
	}

	public override void OnEnter()
	{
		agent.timer.value = 9;

		agent.movement.Stop();
		agent.movement.Velocity = Vector3.zero;

		agent.animator?.SetTrigger("Dance");
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}
}
