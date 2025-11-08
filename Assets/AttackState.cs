using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private bool hasDealtDamage = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasDealtDamage = false;
        Debug.Log("Bắt đầu animation Attack");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Gọi damage tại thời điểm 50% của animation
        if (!hasDealtDamage && stateInfo.normalizedTime >= 0.5f)
        {
            animator.GetComponent<ZombieAttack>().OnAttack();
            hasDealtDamage = true;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Kết thúc animation Attack");
    }
}
