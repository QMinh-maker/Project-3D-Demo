using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float radius;
    public int spawnQuantity;
    public float spawnInterval;
    public Transform spawnPoint;

    private bool isRunning;

    //private bool hasStarted = false; //đánh dấu đã vào vùng

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(spawnPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawnPoint.position, 0.2f);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, 0.2f);
    //}
#endif

    //    private void OnDrawGizmosSelected()
    //    {
    //        Handles.color = new Color(1, 0, 0, 0.1f);
    //        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    //    }
    //


    //    private void Update()
    //    {
    //        // Nếu chưa từng chạy và player đã vào vùng radius
    //        if (!hasStarted && Vector3.Distance(PlayerFoot.position, transform.position) <= radius)
    //        {
    //            hasStarted = true;
    //            StartCoroutine(SpawnZombieByTime());
    //        }
    //    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isRunning && other.CompareTag("Player"))
        {
            isRunning = true;
            StartCoroutine(SpawnZombieByTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isRunning && other.CompareTag("Player"))
        {
            isRunning = false;
            StopAllCoroutines();
        }
    }
    private IEnumerator SpawnZombieByTime()
    {
        while (spawnQuantity > 0)
        
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        //Instantiate(zombiePrefab, transform.position, transform.rotation);
        Lean.Pool.LeanPool.Spawn(zombiePrefab, transform.position, transform.rotation);
        spawnQuantity--;

    }
}
