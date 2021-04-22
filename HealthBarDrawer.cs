using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDrawer : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Health _healthBar;

    private float _currentSliderValue;
    private float _newSliderValue;
    private float _maxHealth;
    private float _health;

    private void OnEnable()
    {
        _healthBar.OnHealthChanged += RewriteHealthValues;
    }
    private void OnDisable()
    {
        _healthBar.OnHealthChanged -= RewriteHealthValues;
    }

    private void Start()
    {
        _healthBarSlider.value = 1;
        RewriteHealthValues();
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

    private void RewriteHealthValues()
    {
        _maxHealth = _healthBar.MaxHealth;
        _health = _healthBar.CurrentHealth;
        WriteSliderValues();
    }
}
