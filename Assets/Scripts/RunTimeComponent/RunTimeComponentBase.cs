using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UOP1.StateMachine.ScriptableObjects;

public class RunTimeComponentBase<T> : DescriptionSMActionBaseSO where T : UnityEngine.Object
{
    public UnityAction OnCompProvided;

    [Header("Debug")] 
    [ReadOnly] public bool isSet = false;

    [ReadOnly] [SerializeField] private T _value;
    public T Value
    {
        get { return _value; }
    }

    public void Provide(T value)
    {
        if(value == null)
        {
            Debug.LogError("A null value was provided to the " + this.name + " runtime component.");
            return;
        }

        _value = value;
        isSet = true;
		
        if(OnCompProvided != null)
            OnCompProvided.Invoke();
    }

    public void Unset()
    {
        _value = null;
        isSet = false;
    }

    private void OnDisable()
    {
        Unset();
    }
}
