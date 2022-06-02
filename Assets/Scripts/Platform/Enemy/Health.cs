using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float _health;
    private float _maxHealth;

    public Health(float startHealth, float maxHealth)
    {
        _health = startHealth;
        _maxHealth = maxHealth;
    }
    public void LessHealth(float damage)
    {
        _health -= damage;
        _health = Mathf.Max(0, _health);
    }
    public bool IsDie()
    {
        return _health <= 0;
    }
    public float GetFillAmount()
    {
        return _health / _maxHealth;
    }
}
