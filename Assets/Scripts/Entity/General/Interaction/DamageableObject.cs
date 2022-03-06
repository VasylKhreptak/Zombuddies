using System;
using UnityEngine;

public class DamageableObject : MonoBehaviour, IHealth
{
    [Header("Data")]
    [SerializeField] private DamageableObjectData _data;
    
    private float _health;

    private bool IsAlive => _health > 0;

    public float Health => _health;

    public Action<float> onTakeDamage;
    public Action onDeath;

    #region MonoBehaviour

    private void OnEnable()
    {
        SetHealth(_data.MaxHealth);
    }

    #endregion
    
    private void SetHealth(float health) => _health = health;

    public void TakeDamage(float damage)
    {
        onTakeDamage?.Invoke(damage);
        
        _health -= damage;
        
        if (IsAlive == false)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        onDeath?.Invoke();
    }
}
