using Charactor;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsEntityGettingHit", menuName = "State Machines/Conditions/Is Entity Getting Hit")]
public class IsEntityGettingHitSO : StateConditionSO
{
    protected override Condition CreateCondition() => new IsEntityGettingHit();
}

public class IsEntityGettingHit : Condition
{
    private bool _isEmpty;
    private Damageable _damageable;

    public override void Awake(UOP1.StateMachine.StateMachine stateMachine)
    {
        _isEmpty = !stateMachine.TryGetComponent(out _damageable);
    }
	
    protected override bool Statement()
    {
        if (_isEmpty)
            return false;

        return _damageable.GetHit;
    }

    public override void OnStateExit()
    {
        _damageable.GetHit = false;
    }
}