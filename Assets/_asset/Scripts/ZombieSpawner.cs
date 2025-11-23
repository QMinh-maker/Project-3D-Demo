using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float radius;
    public int spawnQuantity;
    public float spawnInterval;
    public Transform PlayerFoot;

    private bool hasStarted = false; //đánh dấu đã vào vùng

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    }
#endif

    //private void Start()
    //{
    //    StartCoroutine(SpawnZombieByTime());
    //}
    private void Update()
    {
        // Nếu chưa từng chạy và player đã vào vùng radius
        if (!hasStarted && Vector3.Distance(PlayerFoot.position, transform.position) <= radius)
        {
            hasStarted = true;
            StartCoroutine(SpawnZombieByTime());
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
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        spawnQuantity--;
    }
}
