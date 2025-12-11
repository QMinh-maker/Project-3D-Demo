using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;
    public ZombieAttack zombieAttack;


    private bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value) return;
            _isMovingValue = value;
            OnIsMovingValueChanged();
        }
    }

    private void OnIsMovingValueChanged()
    {
        agent.isStopped = !_isMovingValue;
        anim.SetBool("IsWalking", _isMovingValue);
        if (_isMovingValue)
        {
            onStartMoving.Invoke();

        }
        else
        {
            onDestinationReached.Invoke();

        }
    }

    private void Start()
    {
        playerFoot = Player.Instance.playerFoot;
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        if (distance > reachingRadius)
        {
            anim.SetBool("IsWalking", true);
            agent.isStopped = false;
            agent.SetDestination(playerFoot.position);            
            zombieAttack.StopAttack();
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("IsWalking", false);
            zombieAttack.StartAttack();
            //Debug.Log("Attacking Player");            
        }
    }

    public void OnDie()
    {
        enabled = false;
        agent.isStopped = true;
        anim.SetTrigger("Die");
        // tắt Collider để không cản vật khác
        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // cho xác nằm lại vài giây rồi xoá
        StartCoroutine(DisappearAfterSeconds(3f));  // 3 giây = tuỳ chỉnh
    }

    private System.Collections.IEnumerator DisappearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
