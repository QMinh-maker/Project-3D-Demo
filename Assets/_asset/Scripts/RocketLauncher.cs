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
    //public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            //ShootBullet();
            PlayFireSound();
            AddProjectile();
            
        }
    }

    //private void ShootBullet() => anim.SetTrigger("Shoot");
    private void PlayFireSound() => ShootingSound.Play();
    private void AddProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab,firingPos.position,firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firingPos.forward * bulletSpeed;
    }

}
