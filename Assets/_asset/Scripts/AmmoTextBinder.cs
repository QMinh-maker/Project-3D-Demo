using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoTextBinder : MonoBehaviour
{
    public TMP_Text LoadedAmmoText;
    public GunAmmo gunAmmo;
    private void Start()
    {
        gunAmmo.LoadedAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();
    }

    public void UpdateGunAmmo()
    {
        //Debug.Log("UpdateGunAmmo");
        LoadedAmmoText.text = gunAmmo.LoadedAmmo.ToString();
    }
}
