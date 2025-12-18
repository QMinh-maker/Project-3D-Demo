using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.OnPlayerEnterSpawnZone?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.OnPlayerExitSpawnZone?.Invoke();
        }
    }
}

