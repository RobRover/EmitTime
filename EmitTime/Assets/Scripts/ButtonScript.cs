using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	public GameObject openDoor;
	public GameObject closedDoor;

    private Animator anim;
    
	void Start()
	{
		closedDoor.SetActive(true);
		openDoor.SetActive(false);

        anim = this.GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collider)
	{
		closedDoor.SetActive(false);
		openDoor.SetActive(true);
        anim.SetBool("Pressed",true);
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		closedDoor.SetActive(false);
		openDoor.SetActive(true);
        anim.SetBool("Pressed",true);
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		closedDoor.SetActive(true);
		openDoor.SetActive(false);
        anim.SetBool("Pressed",false);
	}

}
