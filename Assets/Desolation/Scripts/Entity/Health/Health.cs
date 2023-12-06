using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Health : IDamagable, IInitializable
{
    public Settings HealthSettings;

    private int _maxHealth = 100;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public event Action OnEntityDeath;

    public Health(Settings settings)
    {
        HealthSettings = settings;
    }

    // ... other settings

    public void Initialize()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Damage");
        int adjustedDamage = Mathf.RoundToInt(amount * (1 - HealthSettings.DamageResistance));
        ModifyHealth(-adjustedDamage);
    }

    public void ModifyHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth == 0) 
            Die();
    }

    public void Die()
    {
        OnEntityDeath?.Invoke();
        // other actions, methods, e.t.c
    }

    [Serializable]
    public class Settings 
    {
        [Header("Resistances")]
        public float DamageResistance;
    }
}
