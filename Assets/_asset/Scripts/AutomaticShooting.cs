using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    public Animator anim;
    public int rpm;
    public AudioSource ShootSound;


    public UnityEvent onShoot;
    public GunRaycaster gunRaycaster;
    public GunAmmo gunAmmo;

    private float lastShot;
    private float interval;

    void Start()
    {
        interval = 60f / rpm;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
            
        }
        else
        {
            anim.Play("Ak_idle");
        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
        
    }

    private void Shoot()
    {
        anim.Play("AK_Shoot", layer: -1, normalizedTime: 0);
        ShootSound.Play();
        gunAmmo.SingleFireAmmoCounter();
        gunRaycaster.PerformRaycasting();
        onShoot.Invoke();
        
    }

}
