using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    private void LateUpdate()
    {
        Relocate();
    }

    public void Relocate()
    {
        transform.position = target.position + offset;
    }
}
