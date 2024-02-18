using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 10;
    public bool isReloading;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
            Reload();
        }
    }
    void Shoot()
    {
        if (isReloading) { return; }
        if (ammo <= 1)
        {
            Reload();
            return;
        }
        ammo--;
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
