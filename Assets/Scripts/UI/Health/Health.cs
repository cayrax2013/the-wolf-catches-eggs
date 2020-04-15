using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private UnityEventInt _onHealthChanged;

    public event UnityAction Died;

    private void Start()
    {
        _onHealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        _onHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public void TakeHealth(int amountHealth)
    {
        _currentHealth += amountHealth;

        if (_currentHealth > 100)
            _currentHealth = 100;

        _onHealthChanged?.Invoke(_currentHealth);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
