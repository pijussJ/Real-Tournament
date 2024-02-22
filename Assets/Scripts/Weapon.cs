using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField]int ammo;
    public int maxAmmo;
    public int clipAmmo;
    public int clipSize;

    public bool isAutoFire;
    public float shootInterval = 0.5f;
    public int bulletsPerShot = 1;
    public float spreadAngle;

    public UnityEvent onRightClick;
    public UnityEvent onReload;
    public UnityEvent onShoot;

    bool isReloading;
    float shootCooldown;

    private void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;
        
        // Manual fire
        if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        // Auto fire
        if(isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            onRightClick.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
            Reload();
        }
    }

    public void Shoot()
    {
        if (isReloading) return;
        if (shootCooldown > 0) return;
        if (clipAmmo <= 1)
        {
            Reload();
        }

        onShoot.Invoke();
        shootCooldown = shootInterval;

        for (int i = 0; i < bulletsPerShot; i++)
        {
            if (clipAmmo > 0)
            {
                clipAmmo--;         
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.eulerAngles += Vector3.one * Random.Range(-spreadAngle, spreadAngle);
            }
        }
    }

    async void Reload()
    {
        if (isReloading) return;

        isReloading = true;
        onReload.Invoke();
        await new WaitForSeconds(2);
        //ammo = maxAmmo;
        var ammoToReload = Mathf.Min(ammo, clipSize);
        ammo -= ammoToReload;
        clipAmmo += ammoToReload;
        isReloading = false;
    }
}
