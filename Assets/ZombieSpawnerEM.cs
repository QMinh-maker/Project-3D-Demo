using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerEM : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int spawnQuantity;
    public float spawnInterval;
    public Transform spawnPoint;

    private bool isRunning;

    private void OnEnable()
    {
        EventManager.OnPlayerEnterSpawnZone += StartSpawn;
        EventManager.OnPlayerExitSpawnZone += StopSpawn;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerEnterSpawnZone -= StartSpawn;
        EventManager.OnPlayerExitSpawnZone -= StopSpawn;
    }

    private void StartSpawn()
    {
        if (isRunning) return;

        isRunning = true;
        StartCoroutine(SpawnZombieByTime());
    }

    private void StopSpawn()
    {
        if (!isRunning) return;

        isRunning = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnZombieByTime()
    {
        while (spawnQuantity > 0 && isRunning)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        Lean.Pool.LeanPool.Spawn(
            zombiePrefab,
            spawnPoint != null ? spawnPoint.position : transform.position,
            transform.rotation
        );

        spawnQuantity--;
    }
}
