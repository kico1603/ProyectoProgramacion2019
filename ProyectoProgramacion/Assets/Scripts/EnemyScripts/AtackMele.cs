using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMele : MonoBehaviour
{
    GameObject player;
    PlayerDataLife playerLife;

    public float fireRate;

    private float nextFire;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerDataLife>();
        nextFire = Time.time + fireRate;
    }




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                playerLife.addDamage(40);
            }
        }
    }



}
