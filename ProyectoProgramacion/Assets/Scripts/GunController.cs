﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject shot;
    public float fireRate;
    private float nextFire;
    public float ammunition;
    public float ammunitionOriginal;
    public float charger;
    public float maxCharger;
    bool shootMun;


    void Start()
    {
        nextFire = 0;
        shootMun = true;
        ammunitionOriginal = ammunition;
    }

    // Update is called once per frame
    public void shoot()
    {
        if (Time.time > nextFire)
        {
            if (charger <= 0)
            {
                charger = 0;
                shootMun = reload();
            }
            else
            {
                shootMun = true;
            }

            if (shootMun) {
                charger--;
                nextFire = Time.time + fireRate;
                GameObject instance = Instantiate(shot, transform.position, transform.rotation);
            }

        }
    }

    public void restore()
    {
        charger = maxCharger;
        ammunition = ammunitionOriginal;
        nextFire = 0;
    }

    public void addAmunition(float amunitionAdd) {
        ammunition += amunitionAdd;

        if (ammunition > ammunitionOriginal) {
            ammunition = ammunitionOriginal;
        }
    }

    public bool reload()
    {
        if (ammunition <= 0)
        {
            ammunition = 0;
            return false;
        }
        else if (ammunition < maxCharger)
        {
            charger = ammunition;
            ammunition = 0;
        }
        else
        {
            ammunition -= maxCharger;
            charger = maxCharger;
        }
        return true;
    }



}
