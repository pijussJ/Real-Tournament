using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMod : MonoBehaviour
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

        if (isBurstFire)
        {
            weapon.multiMode = 7;
            weapon.isAutoFire = false;
        }
        else
        {
            weapon.multiMode = 1;
            weapon.isAutoFire = true;
        }
    }
}
