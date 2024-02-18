using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20;
    public int damage = 10;
    public GameObject explosionParticles;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.Damage(damage);
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
    }
}
