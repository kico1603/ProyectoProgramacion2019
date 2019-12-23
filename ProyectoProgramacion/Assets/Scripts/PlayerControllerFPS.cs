using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFPS : MonoBehaviour
{
    //Desplazamiento en los ejes X y Z
    float movX;
    float movZ;
   
    //rotación en el eje vertical 
    float rotY;
    Vector3 mov;

    //las velocidades de movimiento y rotación
    public float velInitial = 800f;
    public float velInRun = 1600f;
    public float vel;
    public float velRot = 180.0f;



    //Camera

    //vector para almacenar la rotación de la cámara
    Vector3 currentRot;
    //límites de la rotación
    float minRot = -30.0f;
    float maxRot = 90.0f;
    float rotX;
    public GameObject mainCamera;

    //CharacterController and Gravity

    private CharacterController player;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentRot = mainCamera.transform.eulerAngles;

        //CharacterController
        player = GetComponent<CharacterController>();

        vel = velInitial;
    }

    // Update is called once per frame
    void Update()
    {
        currentRot.x -= Input.GetAxis("Mouse Y") * velRot * Time.deltaTime;
        currentRot.x = Mathf.Clamp(currentRot.x, minRot, maxRot);
        mainCamera.transform.localEulerAngles = currentRot;

        rotY = Input.GetAxis("Mouse X") * velRot * Time.deltaTime;
        transform.Rotate(0, rotY, 0);
        movX = Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime;
        movZ = Input.GetAxisRaw("Vertical") * vel * Time.deltaTime;
        mov = new Vector3(movX, 0.0f, movZ);
        
        //transform.Translate(mov);

        setGravity();
        PlayersMovement();


        player.Move(transform.TransformDirection(mov) * Time.deltaTime);

        
    }

    private void PlayersMovement()
    {
        //Salto

        if (player.isGrounded && Input.GetButton("Jump"))
        {
            fallVelocity = jumpForce;
            mov.y = fallVelocity;

        }

        if (Input.GetButton("Run"))
        {
            vel = velInRun;
        }
        else {
            vel = velInitial;
        }


    }

    private void setGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
        }

        mov.y = fallVelocity;
    }
}
