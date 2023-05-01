using Charactor;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ArriveEndPointCondition", menuName = "State Machines/Conditions/Arrive End Point Condition")]
public class ArriveEndPointConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new ArriveEndPointCondition();
}

public class ArriveEndPointCondition : Condition
{
	private CharactorBrain _charactor;
	public override void Awake(UOP1.StateMachine.StateMachine stateMachine)
	{
		_charactor = stateMachine.GetComponent<CharactorBrain>();
	}
	
	protected override bool Statement()
	{
		return _charactor.Arrived;
	}
}
