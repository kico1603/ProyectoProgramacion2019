using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody rb;
    Vector3 forward;
    bool death;

    private void Start()
    {
        Destroy(this.gameObject, 5);
        rb = GetComponent<Rigidbody>();
        forward = transform.forward;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!death)
            rb.velocity = forward * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        death = true;
    }


}
