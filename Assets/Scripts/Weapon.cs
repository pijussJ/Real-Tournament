using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;

	public int ammo;
	public int maxAmmo = 10;
	public int clipAmmo;
	public int clipSize;

	public bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;
	public int multiMode = 1;

	public float spread;

	public UnityEvent onRightClick;
	public UnityEvent onShoot;
	public UnityEvent onReload;

	void Update()
	{
		// manual mode
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}

		// auto mode
		if(isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			Shoot();
		}

		if( Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
		{
			Reload();
		}
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			onRightClick.Invoke();
		}

        

		fireCooldown -= Time.deltaTime;


	}

	public void Shoot()
	{
		if(isReloading) return;
		if (clipAmmo <= 0)
		{
			Reload();
			return;
		}
		if(fireCooldown > 0) return;
		clipAmmo--;
		fireCooldown = fireInterval;


		for (int i = 0; i < multiMode; i++)
		{
			if (clipAmmo > 0)
			{
				var rot = transform.rotation * Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
				Instantiate(bulletPrefab, transform.position, rot);
			}
		}
		onShoot.Invoke();
	}


	async void Reload()
	{
		if (isReloading) return;
		isReloading = true;

		onReload.Invoke();
		await new WaitForSeconds(2f);

		//ammo = maxAmmo;
		var ammoToReload = Mathf.Min(ammo, clipSize);
		ammo -= ammoToReload;
		clipAmmo += ammoToReload;

		isReloading = false;
		print ("Reloaded");
	}
}