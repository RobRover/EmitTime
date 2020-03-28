using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] public CharacterController2D controller;

	[SerializeField] public float runSpeed = 40f;

	private CircleCollider2D cir_col;

	float horizontalMove = 0f;
	bool jump = false;
	bool izq_col_midair = false;
	bool der_col_midair = false;

	void Start() {
		cir_col = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			controller.Jump();
		}


		if(Input.GetKeyDown(KeyCode.LeftShift) ){
			controller.Flip();
        }
	}

	void FixedUpdate ()
	{
		// Restrict speed with lateral colissions
		if (izq_col_midair) {
			horizontalMove = Mathf.Clamp(horizontalMove, 0, runSpeed);
		}
		if (der_col_midair) {
			horizontalMove = Mathf.Clamp(horizontalMove, runSpeed * (-1), 0);
		}
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	void OnCollisionEnter2D(Collision2D collision)  {

		if (!controller.m_Grounded) {
			// Check if there is a lateral collsion midair
			foreach (ContactPoint2D colision in collision.contacts) {
				Vector3 contactPoint = collision.contacts[0].point;
				Vector3 center = cir_col.bounds.center;

				// If the collision is lateral and not in the bottom
				if (contactPoint.x > center.x) {
					der_col_midair = true;
					break;
				} else if (contactPoint.x < center.x) {
					der_col_midair = true;
					break;
				}

			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		// To-Do repeat the OnCollsionMethod here, but if this work....
		der_col_midair = false;
		der_col_midair = false;
	}
}