using Charactor;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "MoveToNextCubeAction", menuName = "State Machines/Actions/Move To Next Cube Action")]
public class MoveToNextCubeActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new MoveToNextCubeAction();
}

public class MoveToNextCubeAction : StateAction
{
	private CharactorBrain _charactor;
	private PathNodeCube _nextCube;
	public override void Awake(UOP1.StateMachine.StateMachine stateMachine)
	{
		_charactor = stateMachine.GetComponent<CharactorBrain>();
	}
	
	public override void OnUpdate()
	{
		if(Vector3.Distance(_charactor.transform.position, _nextCube.transform.position) <= 0.1f)
		{
			Debug.Log($"Arrived {_nextCube.gameObject.name}");
			_charactor.CurrentCube = _nextCube;
			if(_charactor.CurrentCube.IsEndPoint)
			{
				_charactor.Arrived = true;
				return;
			}
			
			_charactor.movementVector = _nextCube.Direction.normalized * _charactor.data.moveSpeed;
			_nextCube = _charactor.CurrentCube.NextCube;
		}
	}
	
	public override void OnStateEnter()
	{
		_charactor.movementVector = _charactor.CurrentCube.Direction.normalized * _charactor.data.moveSpeed;
		_nextCube = _charactor.CurrentCube.NextCube;
		Debug.Log($"{_nextCube.gameObject.name}");

	}
	
	public override void OnStateExit()
	{
	}
}
