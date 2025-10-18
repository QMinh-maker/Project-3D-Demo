using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : MonoBehaviour
{
    //public Animator anim;
    public int rpm;
    public AudioSource ShootSound;
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask LayerMask;

    public UnityEvent onShoot;



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
        //anim.Play("Shoot", layer: -1, normalizedTime: 0);
        ShootSound.Play();
    }
}
