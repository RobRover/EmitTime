using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

	public GameObject door;
    private void OnTriggerEnter2D(Collider2D collider)
	{
		door.SetActive(false);
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		Debug.Log("Trigger!");
		door.SetActive(false);
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log("Trigger!");
		door.SetActive(true);
	}

}
