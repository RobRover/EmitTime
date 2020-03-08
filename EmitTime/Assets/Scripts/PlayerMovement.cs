using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigib;
    public Transform ground_check;
	public CharacterController2D controller;
    public LayerMask layer_ground;

	public float runSpeed = 10f;
    public float jumpSpeed = 20f;

	float horizontalMove = 0f;
	bool can_jump = false;
    bool is_in_ground;
    
    void Start() {
        rigib = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (is_in_ground && (Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.UpArrow))) {
			can_jump = true;
		}
		
		if (Manager.Instance.is_inverted) {
            horizontalMove *= -1;
        }
	}

	void FixedUpdate() {
		// Move our character
		//controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		//Vector3 targetVelocity = new Vector2(horizontalMove * 10f, rigib.velocity.y);
        // And then smoothing it out and applying it to the character
        rigib.velocity = new Vector2(horizontalMove, rigib.velocity.y);
        //jump = false;
        if (can_jump) {
            Debug.Log(can_jump);
            rigib.AddForce(new Vector2(0f, jumpSpeed));
            can_jump = false;
            is_in_ground = false;
        }
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ground_check.position, .2f, layer_ground);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				is_in_ground = true;
				break;
			} else {
                is_in_ground = false;
            }
		}
	}
}
