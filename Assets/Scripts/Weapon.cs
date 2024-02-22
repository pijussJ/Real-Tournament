using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]int ammo;
    public int maxAmmo;
    public bool isAutoFire;
    public float shootInterval = 0.5f;
    public int multiBullet = 1;
    public float spread;

    bool isReloading;
    float shootCooldown;

    public GameObject bulletPrefab;

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

        if(Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (isReloading) return;
        if (shootCooldown > 0) return;
        //if (ammo <= 1)
        if (ammo <= multiBullet)
        {
            Reload();
        }

        shootCooldown = shootInterval;

        for (int i = 0; i < multiBullet; i++)
        {
            if (ammo > 0)
            {
                ammo--;
                var rot = transform.rotation * Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
                Instantiate(bulletPrefab, transform.position, rot);
            }
        }
    }

    async void Reload()
    {
        if (isReloading) return;

        isReloading = true;
        await new WaitForSeconds(2);
        isReloading = false;
        ammo = maxAmmo;
    }
}
