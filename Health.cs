using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;
    [SerializeField] private float _maxHealth;

    private float _health;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

   
    public event UnityAction OnHealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
    }
    public void TakeDamage()
    {
        if (_health >= _damage)
        {
            _health = ChangeHealth(-_damage);
            OnHealthChanged?.Invoke();
        }
        else
        {
            _health = 0;
            OnHealthChanged?.Invoke();
        }
    }

    public void Heal()
    {
        if (_health < _maxHealth)
        {
            _health = ChangeHealth(_heal);
            OnHealthChanged?.Invoke();
        }
        else
        {
            _health = _maxHealth;
            OnHealthChanged?.Invoke();
        }
    }

    private float ChangeHealth(float value)
    {
        float newHealthValue;
        newHealthValue = _health + value;
        return newHealthValue;
    }


}
