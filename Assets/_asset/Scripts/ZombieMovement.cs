using System.Collections;
using System.Collections.Generic;
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


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        if (distance > reachingRadius) 
        {
            agent.isStopped = false;
            agent.SetDestination(playerFoot.position);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            agent.isStopped=true;
            anim.SetBool("IsWalking",false);
        }
    }
}
