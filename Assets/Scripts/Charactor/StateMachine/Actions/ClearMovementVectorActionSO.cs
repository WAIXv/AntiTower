using Charactor;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ClearMovementVectorAction", menuName = "State Machines/Actions/Clear Movement Vector Action")]
public class ClearMovementVectorActionSO : StateActionSO
{
	public StateAction.SpecificMoment _moment;
	protected override StateAction CreateAction() => new ClearMovementVectorAction();
}

public class ClearMovementVectorAction : StateAction
{
	private CharactorBrain _charactor;
	private SpecificMoment _moment;
	private ClearMovementVectorActionSO _originSO => OriginSO as ClearMovementVectorActionSO;
	public override void Awake(UOP1.StateMachine.StateMachine stateMachine)
	{
		
		_charactor = stateMachine.GetComponent<CharactorBrain>();
	}
	
	public override void OnUpdate()
	{
		if(_moment == SpecificMoment.OnUpdate)
			_charactor.movementVector = Vector3.zero;
	}
	
	public override void OnStateEnter()
	{
		if(_moment == SpecificMoment.OnStateEnter)
			_charactor.movementVector = Vector3.zero;
	}
	
	public override void OnStateExit()
	{
		if(_moment == SpecificMoment.OnStateExit)
			_charactor.movementVector = Vector3.zero;
	}
}
