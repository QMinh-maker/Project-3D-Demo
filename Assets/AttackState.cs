using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private bool hasDealtDamage = false;
    private ZombieAttack zombieAttack;

    // Khi vào state Attack
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasDealtDamage = false;
        if (zombieAttack == null)
            zombieAttack = animator.GetComponent<ZombieAttack>();

        Debug.Log("Bắt đầu animation Attack");
    }

    // Khi animation đang chạy
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Gọi gây damage ở giữa animation
        if (!hasDealtDamage && stateInfo.normalizedTime >= 0.5f)
        {
            if (zombieAttack != null)
            {
                // Random vết chém trái/phải
                int hitIndex = Random.Range(0, 2);
                zombieAttack.OnAttack(hitIndex);
            }
            hasDealtDamage = true;
        }

        // Nếu animation chạy xong 1 vòng → reset để lặp lại liên tục
        if (stateInfo.normalizedTime >= 1.0f)
        {
            hasDealtDamage = false; // cho phép đánh lại vòng kế tiếp
        }
    }

    // Khi thoát khỏi state Attack
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Kết thúc animation Attack");
    }
}
