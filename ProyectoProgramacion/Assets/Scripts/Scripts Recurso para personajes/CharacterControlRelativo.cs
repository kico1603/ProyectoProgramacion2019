using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlRelativo : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	//ROTACION
	public float rot_speed = 2.0f;
	//Relativo a camara
	public Transform Ref_Cam;

	//Velocidad en el Aire
	public float speedAirController = 4f;

	void Update() {

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			
			//CONTROL RELATIVO A CAMARA
			moveDirection = Ref_Cam.TransformDirection (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")));



			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}else {
			//CONTROL AEREO
			Vector3 tempdirection =  Ref_Cam.TransformDirection (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")));
			moveDirection.x = tempdirection.x * speedAirController;
			moveDirection.z = tempdirection.z * speedAirController;
		}




	
		//ROTACION RELATIVO A CAMERA
		Vector3 temp_Rot_Vector = Ref_Cam.TransformDirection (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")));

		if (temp_Rot_Vector.magnitude > 0.1f) {

			transform.forward = temp_Rot_Vector.normalized;

		}


		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
