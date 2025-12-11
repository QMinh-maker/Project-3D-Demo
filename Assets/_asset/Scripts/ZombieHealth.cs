using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class ZombieHealth : Health
{
    
    protected override void Die()
    {
        base.Die();
        //EventManager.EmitEvent("OnZombieKilled", gameObject);
        MissionManager.Instance.OnZombieKilled(gameObject);
        
    }
}
