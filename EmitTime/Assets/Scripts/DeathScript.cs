using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    	
    }

    void Update(){
    	
    }

	void OnCollisionEnter2D(Collision2D col)
    {
    	Manager.Instance.sceneManager.ResetCurrentLevel();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Manager.Instance.sceneManager.ResetCurrentLevel();
    }
}
