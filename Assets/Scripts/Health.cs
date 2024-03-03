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

    public AudioClip damageSFX;
    public AudioClip dieSFX;
    private void Start()
    {
        if (health == 0) health = maxHealth;
    }

    public void Damage(int damage)
    {
        health -= damage;
        onDamage.Invoke();
        AudioSystem.Play(damageSFX);
        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        if(health <= 0)
        {
            Die();
        }
        if (health < 0) health = 0;
    }

    public void Die()
    {
        onDie.Invoke();
        if (shouldDestroy) Destroy(gameObject);
        if(deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
        AudioSystem.Play(dieSFX);
    }
}
