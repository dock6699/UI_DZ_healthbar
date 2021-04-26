using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Health _healthBar;

    private float _currentSliderValue;
    private float _newSliderValue;
    private float _maxHealth;
    private float _health;

    private void OnEnable()
    {
        _healthBar.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _healthBar.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _healthBarSlider.value = 1;
        OnHealthChanged();
    }

    private void Update()
    {
        RefreshHealthBar();
    }

    private void RefreshHealthBar()
    {
        if (_currentSliderValue != _newSliderValue)
        {
            _healthBarSlider.value = Mathf.MoveTowards(_currentSliderValue, _newSliderValue, 0.5f * Time.deltaTime);
            WriteSliderValues();
        }
    }

    private void WriteSliderValues()
    {
        _currentSliderValue = _healthBarSlider.value;
        _newSliderValue = _health / _maxHealth;
    }

    private void OnHealthChanged()
    {
        _maxHealth = _healthBar.MaxHealth;
        _health = _healthBar.CurrentHealth;
        WriteSliderValues();
    }
}
