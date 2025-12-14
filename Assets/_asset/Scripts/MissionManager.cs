using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class MissionManager : Singleton<MissionManager>
{
    public GameFlow gameFlow;
    public int requiredKill;
    public TMP_Text missionText;
    public Gate gate;
    private bool isPlayerExit;

    private int currentKill;

    private void Start()
    {
        StartCoroutine(VerifyMission());
        //EventManager.StartListening("OnZombieKilled", OnZombieKilled);
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
        gate.OnPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        gate.OnPlayerEnter.RemoveListener(OnPlayerExit);
    }

    private void OnPlayerExit()
    {
        isPlayerExit = true;
    }
    
    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
        
    }
 
}
