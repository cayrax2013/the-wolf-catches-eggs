using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private UnityEventInt _onHealthChanged;

    private void Start()
    {
        _onHealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _onHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        // TODO: GameOver
        Debug.Log("Game over");
    }
}
