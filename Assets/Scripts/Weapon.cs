using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 10;
    public bool isReloading;
    public bool isAutoFire;
    public float shootInterval = 0.5f;
    float shootCooldown;
    void Update()
    {
        // manual fire
        if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
            Reload();
        }

        shootCooldown -= Time.deltaTime;
    }
    void Shoot()
    {
        if (isReloading) { return; }
        if (ammo <= 1)
        {
            Reload();
            return;
        }
        if (shootCooldown >0)
        {
            return;
        }


        ammo--;
        shootCooldown = shootInterval;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
    async void Reload()
    {
        if (isReloading) { return; }
        isReloading = true;
        await new WaitForSeconds(2);
        isReloading = false;
        ammo = maxAmmo;
    }
}
