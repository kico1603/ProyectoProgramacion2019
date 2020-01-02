using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public float durationTravel;
    private float nextFire;
    public bool explosion;
    public float radius = 5f;
    public float forceExplosion = 60f;
    public LayerMask layerEx;


    Rigidbody rb;
    Vector3 forward;
    bool death;
    

    private void Start()
    {
        Destroy(this.gameObject, 5);
        rb = GetComponent<Rigidbody>();
        forward = transform.forward;
        death = false;
        nextFire = Time.time + durationTravel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            death = true; 
        }

        if (!death)
            rb.velocity = forward * bulletSpeed * Time.deltaTime;
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        death = true;

        if (explosion) {
            explosion = false;
            doExplosion(transform.position);
        }

        Destroy(this.gameObject, 1);
    }

    private void doExplosion(Vector3 point)
    {
        Collider[] objetosExplotados = Physics.OverlapSphere(point, radius, layerEx);

        foreach (Collider col in objetosExplotados)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                if (col.tag == "Enemy") {
                    EnemyDataLife dataLife = col.GetComponent<EnemyDataLife>();
                    if (dataLife == null) {
                        Debug.LogError("dataLife is NULL!!! Object " + col.name);

                    } else { 
                    float distance = Vector3.Distance(col.transform.position, transform.position);
                    float damage = (distance * 100) / radius;
                    dataLife.addDamage(damage);
                    }
                }
                rb.AddExplosionForce(forceExplosion, point, radius, 0.05f, ForceMode.Impulse);
            }
        }
    }

}
