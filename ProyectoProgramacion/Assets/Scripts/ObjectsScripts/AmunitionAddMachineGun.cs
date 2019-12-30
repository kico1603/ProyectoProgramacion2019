﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmunitionAddMachineGun : MonoBehaviour
{
    
    PlayerColisionManage playerManage;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerManage = player.GetComponent<PlayerColisionManage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            playerManage.addMachineGun();
            Destroy(this.gameObject);
        }
    }


}
