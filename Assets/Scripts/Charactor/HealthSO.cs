using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterHealth", menuName = "Game/Character's Health")]
public class HealthSO : ScriptableObject
{
    [SerializeField] [ReadOnly] private int _maxHealth;
    [SerializeField] [ReadOnly] private int _currentHealth;

    /// <summary>
    /// HealthValue变更时调用，传入参数为最新value
    /// </summary>
    public IntEventChannelSO OnHealthValueChange;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public void SetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public void SetCurrentHealth(int newValue)
    {
        Debug.Log($"{this.name} currentHealth = {newValue}");
        _currentHealth = newValue;
        if (OnHealthValueChange != null) 
            OnHealthValueChange.RaiseEvent(_currentHealth);
    }

    public void ApplyDamage(int delta)
    {
        _currentHealth -= delta;
        if (OnHealthValueChange != null) 
            OnHealthValueChange.RaiseEvent(_currentHealth);
    }

    public void RestoreHealth(int healValue)
    {
        _currentHealth += healValue;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        if (OnHealthValueChange != null) 
            OnHealthValueChange.RaiseEvent(_currentHealth);
    }
}
