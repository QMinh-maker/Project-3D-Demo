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

    public Transform cameraHolder;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();

        }
    }
    public void Shoot()
    {
        if (!IsLocked)
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        //Debug.Log("ShootBullet");
        anim.SetTrigger("Shoot");
    }

    public void PlayFireSound()
    {
        //Debug.Log("PlayFireSound");
        ShootingSound.Play();
    }

    public void AddProjectile()
    {
        gunAmmo.SingleFireAmmoCounter();

        //GameObject bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        GameObject bullet = Lean.Pool.LeanPool.Spawn(bulletPrefab,firingPos.position, firingPos.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Hướng bay dựa theo camera
        Vector3 dir = cameraHolder.forward;

        // Tạo đường cong (nâng nhẹ theo trục Y)
        dir = (dir + Vector3.up * 0.2f).normalized;

        rb.velocity = dir * bulletSpeed;

        // optionally nhìn theo hướng bay
        bullet.transform.rotation = Quaternion.LookRotation(dir);
    }

}
