using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] public CharacterController2D controller;

	[SerializeField] public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	void OnCollisionEnter(Collision collision)
    {
       GameObject parent = collision.gameObject.transform.parent.gameObject;
       Debug.Log(parent.name);
       Debug.Log("hola");
    }
}