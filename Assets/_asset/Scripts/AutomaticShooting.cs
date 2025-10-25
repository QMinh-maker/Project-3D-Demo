using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    public Animator anim;
    public int rpm;
    public AudioSource ShootSound;
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;


    public UnityEvent onShoot;
    public GunRaycaster gunRaycaster;
    

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
        anim.Play("Shoot", layer: -1, normalizedTime: 0);
        ShootSound.Play();
        gunRaycaster.PerformRaycasting();
        onShoot.Invoke();
    }

}
