using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public RocketLauncher gun;
    public AudioSource[] ReloadSound;

    public UnityEvent LoadedAmmoChanged;
    public TextMeshProUGUI AmmoCount;

    //public Animator anim;

    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            LoadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0)
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

    private void SingleFireAmmoCounter() => LoadedAmmo--;

    private void LockShooting() => gun.enabled =false;

    private void UnlockShooting() => gun.enabled = true;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (AmmoCount != null)
        {
            AmmoCount.text = $"{LoadedAmmo / magSize}";
        }

    }

    private void Reload()
    {
        //Animation.SetTrigger("Reload");
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
