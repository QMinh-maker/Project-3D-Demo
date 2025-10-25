using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Shooting
{
    private const int LeftMouseButton = 0;
    public GameObject bulletPrefab;
    public Transform firingPos;
    public float bulletSpeed;
    public AudioSource ShootingSound;
    public Animator anim;
    public GunAmmo gunAmmo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            ShootBullet();
            
            
        }
    }

    private void ShootBullet()
    {
        Debug.Log("ShootBullet");
        anim.SetTrigger("Shoot");
    }

    public void PlayFireSound()
    {
        Debug.Log("PlayFireSound");
        ShootingSound.Play();
    }

    public void AddProjectile()
    {
        Debug.Log("AddProjectile");
        gunAmmo.SingleFireAmmoCounter();
        GameObject bullet = Instantiate(bulletPrefab,firingPos.position,firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firingPos.forward * bulletSpeed;
    }

}
