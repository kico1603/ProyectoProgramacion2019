using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject shot;
    public float fireRate;
    private float nextFire;


    void Start()
    {
        nextFire = Time.time + fireRate;
    }

    // Update is called once per frame
    public void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject instance = Instantiate(shot, transform.position, transform.rotation);
           // instance.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }
    }
}
