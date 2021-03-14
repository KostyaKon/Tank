using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float forceFire = 2500f;
    public GameObject efectsExplosion;

    public float radius = 10.0F;
    public float power = 800.0F;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down * forceFire);
        Invoke("DelBullet", 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
        DelBullet();
    }

    private void DelBullet()
    {
        Instantiate(efectsExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Explosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 100.0F);
        }
    }
}
