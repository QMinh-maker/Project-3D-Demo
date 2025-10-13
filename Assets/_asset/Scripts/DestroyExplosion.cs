using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int lifetime = 5;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    
}
