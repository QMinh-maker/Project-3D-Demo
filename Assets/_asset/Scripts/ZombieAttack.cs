using System;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage = 10;
    public Health playerHealth;

    public void StartAttack()
    {
        if (!anim.GetBool("IsAttacking"))
            anim.SetBool("IsAttacking", true);        
    }

    public void StopAttack()
    {
        anim.SetBool("IsAttacking", false);
    }

    // Gọi từ animation event khi zombie vung tay chạm player
    public void OnAttack(int index)
    {
       
        playerHealth.TakeDamage(damage);
        if (index == 1)
        {
            Player.Instance.playerUi.ShowLeftScratch();
        }
        else
        {
            Player.Instance.playerUi.ShowRightScratch();
        }
    }
}
