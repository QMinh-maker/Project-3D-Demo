using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent onDie;

    private int healthPoint;

    private bool IsDead => healthPoint <= 0;

    private void Start()
    {
       healthPoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log("TakeDamage");
        if (IsDead) return;

        healthPoint -= damage;
        //Debug.Log($"curernt healthPoint : {healthPoint} - damage: {damage} ");
        if (IsDead)
        {
            Die();
            //Debug.Log("Die");
        }
        
    }

    private void Die()
    {
        onDie.Invoke();
    }
}
