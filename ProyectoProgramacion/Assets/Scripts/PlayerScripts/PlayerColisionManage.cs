using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisionManage : MonoBehaviour
{

    public PlayerDataLife playerLife;
    public SelectWeaponController weaponController;
    public GameObject granades;

    GunController granadesGun;
    GunController gun;
    GunController Subgun;

    private void Start()
    {
        playerLife = GetComponent<PlayerDataLife>();
        weaponController = GetComponent<SelectWeaponController>();

       granadesGun = granades.GetComponent<GunController>();

         foreach (GameObject item in weaponController.armas)
        {
            if (item.tag == "Pistola") {
                gun = item.GetComponent<GunController>(); 
            }
        }

        foreach (GameObject item in weaponController.armas)
        {
            if (item.tag == "Subfusil")
            {
                Subgun = item.GetComponent<GunController>();
                
            }
        }


    }




    public void addGranades(float amunition) {
        
        granadesGun.addAmunition(amunition);
    }

    public void addAmunGun(float amunition)
    {
        gun.addAmunition(amunition);

    }
    public void addAmunSub(float amunition)
    {
        Subgun.addAmunition(amunition);
    }

    public void addBazooka()
    {
        weaponController.addBazooka();
    }

    public void addMachineGun() {
        weaponController.addAmePesada();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "AttackEnemy")
        {
            playerLife.addDamage(25);
        }
    }


}

