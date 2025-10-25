using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public Shooting shooting;
    public AudioSource[] ReloadSound;
    public Animator anim;
    public UnityEvent LoadedAmmoChanged;
   

    

    private int _loadedAmmoValue;
    public int LoadedAmmo
    {
        get => _loadedAmmoValue;
        set
        {
            _loadedAmmoValue = value;
            LoadedAmmoChanged.Invoke();
            if (_loadedAmmoValue <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShooting();
            }
        }
    }

    private void Start() => RefillAmmo();

    public void SingleFireAmmoCounter() => LoadedAmmo--;

    private void LockShooting() => shooting.enabled =false;

    private void UnlockShooting() => shooting.enabled = true;

    public void OnGunSelected() => UpdateShootingLock();

    private void UpdateShootingLock() => shooting.enabled = _loadedAmmoValue > 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        
    }

    private void Reload()
    {
        anim.SetTrigger("Reload");
        LockShooting();
    }

    public void AddAmmo() => RefillAmmo();

    private void RefillAmmo() => LoadedAmmo = magSize;

    public void PlayReloadp1Sound() => ReloadSound[0].Play();
    public void PlayReloadp2Sound() => ReloadSound[1].Play();
    public void PlayReloadp3Sound() => ReloadSound[2].Play();
    public void PlayReloadp4Sound() => ReloadSound[3].Play();
    public void PlayReloadp5Sound() => ReloadSound[4].Play();


}
