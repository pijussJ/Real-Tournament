using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]int ammo;
    public int maxAmmo;
    public bool isAutoFire;
    public float shootInterval = 0.5f;

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
        if (ammo <= 1)
        {
            Reload();
        }

        ammo--;
        shootCooldown = shootInterval;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
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
