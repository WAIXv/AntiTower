using UnityEngine.Events;

public abstract class EventChannelBase<T> : DescriptionBaseSO
{
    public UnityAction<T> OnEventRaised;

    public virtual void RaiseEvent(T value)
    {
        OnEventRaised?.Invoke(value);
    }
}
