using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMode : MonoBehaviour
{
    public Weapon weapon;

    public bool isBurstFire;

    private void Start()
    {
        weapon.onRightClick.AddListener(BurstFire);
    }

    public void BurstFire()
    {
        isBurstFire = !isBurstFire;

        if(isBurstFire)
        {
            weapon.bulletsPerShot = 7;
        }
        else
        {
            weapon.bulletsPerShot = 1;
        }
    }
}
