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


    public event UnityAction HealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
    }
    public void TakeDamage()
    {
        if (_health >= _damage)
        {
            _health = ChangeHealth(-_damage);
        }
        else
        {
            _health = 0;
        }
        HealthChanged?.Invoke();
    }

    public void Heal()
    {
        if (_health < _maxHealth)
        {
            _health = ChangeHealth(_heal);
        }
        else
        {
            _health = _maxHealth;
        }
        HealthChanged?.Invoke();
    }

    private float ChangeHealth(float value)
    {
        float newHealthValue;
        newHealthValue = _health + value;
        return newHealthValue;
    }


}
