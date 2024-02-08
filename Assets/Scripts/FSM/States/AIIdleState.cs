using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
	

	public AIIdleState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIChaseState));
		transition.AddCondition(new BoolCondition(agent.enemySeen));
		transitions.Add(transition);

		//var condition = new FloatCondition(agent.timer, Condition.Predicate.LESS, 0);
		//condition.IsTrue();
	}

	public override void OnEnter()
	{
		agent.movement.Stop();
		agent.movement.Velocity = Vector3.zero;

		agent.timer.value = Random.Range(1, 2);
	}

	public override void OnUpdate()
	{
		//foreach (var transition in transitions)
		//{
		//	if (transition.ToTransition())
		//	{
		//		agent.stateMachine.SetState(transition.nextState);
		//		break;
		//	}
		//}
		//if (transition.ToTransition()) agent.stateMachine.SetState(transition.nextState);

		//if (Time.time > agent.timer)
		//{
		//	agent.stateMachine.SetState(nameof(AIPatrolState));
		//}

		//var enemies = agent.enemyPerception.GetGameObjects();

		//if (enemies.Length > 0)
		//{
		//	agent.stateMachine.SetState(nameof(AIChaseState)); //attackstate before change
		//}
	}

	public override void OnExit()
	{
		Debug.Log("idle exit");
	}
}
