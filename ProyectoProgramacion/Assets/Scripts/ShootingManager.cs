using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{

    //public GunController arma;
    public GameObject weaponActived;
    public GameObject granades;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetButton("Fire1")) {
            weaponActived.SendMessage("shoot", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButton("Granade"))
        {
            granades.SendMessage("shoot", SendMessageOptions.DontRequireReceiver);
        }

    }
}
