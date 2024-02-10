using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISadState : AIState
{
	

	public AISadState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);

		//var condition = new FloatCondition(agent.timer, Condition.Predicate.LESS, 0);
		//condition.IsTrue();
	}

	public override void OnEnter()
	{
		Debug.Log("I AM SAD!!!!");
		agent.timer.value = 3.5f;

		agent.movement.Stop();
		agent.movement.Velocity = Vector3.zero;

		agent.animator?.SetTrigger("Sad");
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}
}
