using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public int damage;
    public float speed;
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
        Destroy(gameObject);

        var health = collision.gameObject.GetComponent<Health>();
        if (health != null) 
        {
            health.Damage(damage);
        }
    }
}
