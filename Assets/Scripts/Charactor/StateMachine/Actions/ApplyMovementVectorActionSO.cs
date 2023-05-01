using Charactor;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ApplyMovementVectorAction", menuName = "State Machines/Actions/Apply Movement Vector Action")]
public class ApplyMovementVectorActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new ApplyMovementVectorAction();
}

public class ApplyMovementVectorAction : StateAction
{
	private Transform _transform;
	private CharactorBrain _charactor;
	public override void Awake(UOP1.StateMachine.StateMachine stateMachine)
	{
		_charactor = stateMachine.GetComponent<CharactorBrain>();
		_transform = _charactor.transform;
	}
	
	public override void OnUpdate()
	{
		_transform.position += _charactor.movementVector * Time.deltaTime;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
