using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootingManager))]

public class SelectWeaponController : MonoBehaviour
{
    ShootingManager shootingManager;
    public GameObject[] armas;
    int currentIndex;
    float mouseIndex;


    // Start is called before the first frame update
    void Start()
    {
        shootingManager = GetComponent<ShootingManager>();
        currentIndex = 0;
        cambiaArma(currentIndex);
    }

    // Update is called once per frame
    void avanzaArma(int cantidad)
    {
        currentIndex += cantidad;

        if (currentIndex >= armas.Length) {
            currentIndex = currentIndex % armas.Length;
        }

        if (currentIndex < 0)
        {
            currentIndex = armas.Length + currentIndex;
        }
        cambiaArma(currentIndex);
    }

    void cambiaArma(int cantidad)
    {
        currentIndex = cantidad;

        shootingManager.weaponActived = armas[currentIndex];
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     avanzaArma(1);
        // }

        // if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     avanzaArma(-1);
        // }

        //mouseIndex = (int) Input.GetAxisRaw("Mouse ScrollWheel") * 10;

        // avanzaArma(mouseIndex);

        float mouseIndex = Input.GetAxis("Mouse ScrollWheel");
        if (mouseIndex > 0f)
        {
            avanzaArma(1);
        }
        else if (mouseIndex < 0f)
        {
            avanzaArma(-1);
        }
    }

}
