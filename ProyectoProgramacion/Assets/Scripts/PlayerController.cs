using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// https://www.youtube.com/watch?v=g_TIK83OXQY
    /// </summary>


    private float horizntalMove;
    private float verticalMove;
    private CharacterController player;
    private Vector3 playerInput;
    public float speed;
    public float speedMax;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;



    // Start is called before the first frame update
    void Start()
    {
        horizntalMove = 0;
        verticalMove = 0;
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizntalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizntalMove, 0, verticalMove);

        CamDirection();

        player.transform.LookAt(player.transform.position + movePlayer);

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer *= speed;

        playerInput = Vector3.ClampMagnitude(playerInput, speedMax);

        SetGravity();

        PlayersMovement();

        player.Move(movePlayer * Time.deltaTime);
    }

    private void PlayersMovement()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;

        }


    }


    private void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
        }

        movePlayer.y = fallVelocity;
    }

    private void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;


        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }





}
