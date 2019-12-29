using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootingManager))]

public class SelectWeaponController : MonoBehaviour
{
    ShootingManager shootingManager;
    public GameObject[] armas;
    public GameObject bazooka;
    public GameObject amePesada;
    int currentIndex;
    float mouseIndex;
    bool armaGrande;
    PlayerControllerFPS player;


    // Start is called before the first frame update
    void Start()
    {
        shootingManager = GetComponent<ShootingManager>();
        currentIndex = 0;
        cambiaArma(currentIndex);
        armaGrande = false;
        player = GetComponent<PlayerControllerFPS>();

    }

    // Update is called once per frame
    void avanzaArma(int cantidad)
    {
        if (armaGrande) {
            currentIndex = 0;
            armaGrande = false;
            player.ModeSlow(false);
        }

        int auxIndex = currentIndex;

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

        activarSoloEstaArma(armas[currentIndex]);
        shootingManager.weaponActived = armas[currentIndex];
    }

    public void addBazooka() {

        player.ModeSlow(true);
        activarSoloEstaArma(bazooka);
        shootingManager.weaponActived = bazooka;
        armaGrande = true;

    }

    public void addAmePesada()
    {
        player.ModeSlow(true);
        activarSoloEstaArma(amePesada);
        shootingManager.weaponActived = amePesada;
        armaGrande = true;

    }

    void activarSoloEstaArma(GameObject armaActual)
    {
        foreach (GameObject item in armas)
        {
          item.SetActive(false); 
        }
        bazooka.SetActive(false);
        amePesada.SetActive(false);


        armaActual.SetActive(true);
    }

    private void Update()
    {
        float mouseIndex = Input.GetAxis("Mouse ScrollWheel");
        if (mouseIndex > 0f)
        {
            avanzaArma(1);
        }
        else if (mouseIndex < 0f)
        {
            avanzaArma(-1);
        }

        if (Input.GetKey(KeyCode.F1)) {
            addBazooka();
        }

        if (Input.GetKey(KeyCode.F2))
        {
            addAmePesada();
        }

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
    }

}
