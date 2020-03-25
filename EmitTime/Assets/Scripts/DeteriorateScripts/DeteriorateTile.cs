using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeteriorateTile : MonoBehaviour
{
	[SerializeField] public float[] state_start_time;
	[NonSerialized] private int state;
	[NonSerialized] private Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
    	tilemap = GetComponent<Tilemap>();
		state = -1;
    }

    // Update is called once per frame
    void Update()
    {

    	if(state_start_time.Length != 4)
    		return;

    	int new_state = 1;
    	for(int i = 0; i < state_start_time.Length; i++){
    		if(Manager.Instance.time > state_start_time[i])
    			new_state = i + 1;
    	}

    	if(state == new_state)
    		return;

    	state = new_state;

    	for(int i = 0; i < state_start_time.Length; i++){
    		this.transform.GetChild(i).GetComponent<Tilemap>().transform.gameObject.SetActive(false);
    	}



    	this.transform.GetChild(state - 1).GetComponent<Tilemap>().transform.gameObject.SetActive(true);
	}
}
