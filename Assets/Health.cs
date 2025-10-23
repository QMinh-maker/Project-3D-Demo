using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator anim;

    private int healthPoint;

    private bool IsDead => healthPoint <= 0;

    private void Start()
    {
       healthPoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        healthPoint -= damage;
        if (IsDead)
        {
            Die();
            Debug.Log("Die");
        }
    }

    private void Die() => anim.SetTrigger("Die");
}
