using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour //BeSingleton<NotifyZombieKilled>
{

    public GameFlow gameFlow;
    public int requiredKill;
    public TMP_Text missionText;
    public Transform exitDoor;
    public Transform playerFoot;

    private int currentKill;
    private void Start()
    {
        StartCoroutine(VerifyMission());
    }

    private IEnumerator VerifyMission()
    {
        yield return VerifyZombieKill();
        yield return VerifyPlayerExit();
        gameFlow.OnMissionComplete();
    }

    private IEnumerator VerifyZombieKill()
    {
        currentKill = 0;
        missionText.text = $"Kill {requiredKill} zombies";
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }

    private IEnumerator VerifyPlayerExit()
    {
        missionText.text = $"Find exit door";
        yield return new WaitUntil(IsPlayerExit);
    }

    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
    }

    private bool IsPlayerExit()
    {
        float distance = Vector3.Distance(playerFoot.position, exitDoor.position);
        return distance
    }
}
