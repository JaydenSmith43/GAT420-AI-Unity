using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseState : AIState
{
	float initialSpeed;

	public AIChaseState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIAttackState));
		transition.AddCondition(new BoolCondition(agent.enemySeen));
		transition.AddCondition(new FloatCondition(agent.enemyDistance, Condition.Predicate.LESS, 1.25f)); //two condition to be true
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new BoolCondition(agent.enemySeen, false));
		transitions.Add(transition);
	}

	public override void OnEnter()
	{
		agent.movement.Resume();

		initialSpeed = agent.movement.maxSpeed;
		agent.movement.maxSpeed *= 2;
	}

	public override void OnUpdate()
	{
		if (agent.enemySeen) agent.movement.Destination = agent.enemy.transform.position;

		//var enemies = agent.enemyPerception.GetGameObjects();
		//if (enemies.Length > 0 )
		//{
		//	var enemy = enemies[0];
		//	if (Vector3.Distance(agent.transform.position, enemy.transform.position) < 1.25f)
		//	{
		//		agent.stateMachine.SetState(nameof(AIAttackState));
		//	}

		//}
		//else
		//{
		//	agent.stateMachine.SetState(nameof(AIIdleState));
		//}
	}

	public override void OnExit()
	{
		agent.movement.maxSpeed = initialSpeed;
	}
}
