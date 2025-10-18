using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMissle : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position,transform.rotation);
        BlowObject();
        Destroy(gameObject);

    }

    private void BlowObject()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObjects.Length; i++)
        {
            Rigidbody rigidbody = affectedObjects[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce,transform.position,
                    explosionRadius,1,ForceMode.Impulse);
            }
        }
        

    }
}


