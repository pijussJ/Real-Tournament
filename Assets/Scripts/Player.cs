using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]TMP_Text ammoText;
    [SerializeField]TMP_Text healthText;

    [Header("Components")]
    public Health health;
    public Weapon weapon;

    private void Start()
    {
        weapon.onShoot.AddListener(UpdateUI);
        weapon.onReload.AddListener(UpdateUI);
        health.onDamage.AddListener(UpdateUI);
        health.onDie.AddListener(Respawn);
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = health.health + "HP";
        ammoText.text = weapon.clipAmmo + "/" + weapon.ammo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
    }

    void Respawn()
    {
        health.health = health.maxHealth;
        transform.position = Vector3.zero;
        UpdateUI();
    }
}
