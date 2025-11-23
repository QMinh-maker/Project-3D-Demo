using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent onDie;
    public UnityEvent<int, int> onHealthChanged;
    public UnityEvent onTakeDamage;


    private int _healthpointValue;
    public int HealthPoint
    {
        get => _healthpointValue;
        set
        {
            _healthpointValue = value;
            onHealthChanged.Invoke(_healthpointValue, maxHealthPoint);
        }
    }

    private bool IsDead => HealthPoint <= 0;

    private void Start()
    {
        HealthPoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        HealthPoint -= damage;
        onTakeDamage.Invoke();
        Debug.Log($"curernt healthPoint : {HealthPoint} - damage: {damage} ");
        if (IsDead)
        {
            Die();
            //Debug.Log("PlayerDie");
        }
        
    }

    protected virtual void Die()
    {

        onDie.Invoke();
    }
}
