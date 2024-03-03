using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo;
    public int clipAmmo;
    public int clipSize;

    public bool isAutoFire;
    public float shootInterval = 0.5f;
    public int bulletsPerShot = 1;
    public float spreadAngle;
    public float reloadTime = 2f;

    public UnityEvent onRightClick;
    public UnityEvent onReload;
    public UnityEvent onShoot;

    public bool isReloading;
    float shootCooldown;

    public AudioClip shootSound;
    public AudioClip reloadSound;

    private void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (isReloading) return;
        if (shootCooldown > 0) return;
        if (clipAmmo <= 1)
        {
            Reload();
        }

        shootCooldown = shootInterval;

        for (int i = 0; i < bulletsPerShot; i++)
        {
            if (clipAmmo > 0)
            {
                clipAmmo--;         
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.eulerAngles += Vector3.one * Random.Range(-spreadAngle, spreadAngle);
                AudioSystem.Play(shootSound);
            }
        }

        onShoot.Invoke();
    }

    public async void Reload()
    {
        if (isReloading) return;

        isReloading = true;

        onReload.Invoke();
        AudioSystem.Play(reloadSound);

        await new WaitForSeconds(reloadTime);
        //ammo = maxAmmo;
        var ammoToReload = Mathf.Min(ammo, clipSize);
        ammo -= ammoToReload;
        clipAmmo += ammoToReload;
        isReloading = false;
    }
}
