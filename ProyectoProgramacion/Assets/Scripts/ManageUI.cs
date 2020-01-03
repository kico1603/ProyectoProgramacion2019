using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManageUI : MonoBehaviour
{
    public Text textMun;
    public Text textCargador;
    public Text textArma;
    public Text textGranadas;
    public Image lifeUI;


    GameObject player;
    PlayerDataLife playerLife;
    ShootingManager shotMan;
    GameObject armaActual;
    GameObject auxArm;
    GunController armaActualGunController;
    GunController granadasGunController;
    float colorLife;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerDataLife>();
        shotMan = player.GetComponent<ShootingManager>();
        armaActual = shotMan.weaponActived;
        granadasGunController = shotMan.granades.GetComponent<GunController>();
        colorLife = 0;
        putColorLife(0);



    }

    // Update is called once per frame
    void Update()
    {

        armaActual = shotMan.weaponActived;

        if (armaActual != auxArm)
        {

            auxArm = armaActual;
            armaActualGunController = armaActual.GetComponent<GunController>();

            

        }
        textArma.text = "Arma: " + armaActual.name;
        textCargador.text = "Cargador: " + armaActualGunController.charger;
        textMun.text = "Municion: " + armaActualGunController.ammunition;
        textGranadas.text = "Granadas: " + (granadasGunController.charger + granadasGunController.ammunition);

        

        colorLife = Mathf.Clamp(0.6f - (0.6f * playerLife.life / 150), 0, 0.60f);



        putColorLife(colorLife);



    }

    private void putColorLife(float intensity) {
        Color color = new Color();
        color.a = intensity;
        color.r = 1;
        color.g = 0;
        color.b = 0;
        lifeUI.color = color;

    }

    
}
