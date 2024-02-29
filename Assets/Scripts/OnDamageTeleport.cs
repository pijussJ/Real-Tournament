using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageTeleport : MonoBehaviour
{
    private Vector3 randomPos;
    public Health health;
    public float minZ;
    public float maxZ;
    public float x;
    private void Start()
    {
        randomPos = new Vector3(x, 1, Random.Range(minZ, maxZ));
        health.onDamage.AddListener(Teleport);
    }
    public void Teleport()
    {
        transform.position = randomPos;
        randomPos = new Vector3(x, 1, Random.Range(minZ, maxZ));
    }
}
