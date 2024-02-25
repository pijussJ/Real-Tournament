using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public bool shouldDestroy = true;

    public GameObject damageEffect;
    public GameObject deathEffect;

    public UnityEvent onDamage;
    public UnityEvent onDie;

    void Start()
    {
        if(health == 0) health = maxHealth;
    }


    public void Damage(int damage)
    {
        health -= damage;
        onDamage.Invoke();
        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        if (health <= 0)
        {
            Die();
        }
        if (health < 0) health = 0;
    }

    public void Die()
    {
        onDie.Invoke();
        if(shouldDestroy)Destroy(gameObject);
        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);

    }
}