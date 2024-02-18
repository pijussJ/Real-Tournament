using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public int damage;
    public float speed;
    public GameObject explosionPrefab;
    public int bounceCount = 0;
    public GameObject bouncePrefab;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
        
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null) 
        {
            health.Damage(damage);
        }
        var obj = Instantiate(bouncePrefab, transform.position, Quaternion.identity);
        obj.transform.forward = collision.contacts[0].normal;

        if (bounceCount > 0)
        {
            transform.forward = collision.contacts[0].normal;
            bounceCount--;
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
