using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHits : MonoBehaviour, IDamageable
{
    public event Action<float> ChangeAmountHP = delegate { };
    public event Action<EnemyHits> DieEvent = delegate { };

    [SerializeField] int _maxHealth;

    private bool _wasDie = false;
    private Health _health;
    private void Awake()
    {
        _health = new Health(_maxHealth, _maxHealth);
    }
    public void Hit()
    {
        _health.LessHealth(1);
        ChangeAmountHP.Invoke(_health.GetFillAmount());
        if (_health.IsDie() && !_wasDie)
        {
            Die();
        }
    }

    private void Die()
    {
        _wasDie = true;
        DieEvent.Invoke(this);
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    private void OnDestroy()
    {
        ChangeAmountHP = null;
        DieEvent = null;
    }
}
