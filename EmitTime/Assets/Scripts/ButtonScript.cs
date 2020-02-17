using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	public GameObject openDoor;
	public GameObject closedDoor;

	void Start()
	{
		closedDoor.SetActive(true);
		openDoor.SetActive(false);


	}

    private void OnTriggerEnter2D(Collider2D collider)
	{
		closedDoor.SetActive(false);
		openDoor.SetActive(true);
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		closedDoor.SetActive(false);
		openDoor.SetActive(true);
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		closedDoor.SetActive(true);
		openDoor.SetActive(false);
	}

}
