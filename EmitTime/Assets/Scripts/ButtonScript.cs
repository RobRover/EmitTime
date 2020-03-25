using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	private GameObject openDoor;
	private GameObject closedDoor;
    private Animator anim;
    public bool isPressed;
    
	void Start()
	{

		isPressed = false;
        anim = this.GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collider)
	{
		isPressed = true;
        anim.SetBool("Pressed",true);
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		isPressed = true;
        anim.SetBool("Pressed",true);
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		isPressed = false;
        anim.SetBool("Pressed",false);
	}

}