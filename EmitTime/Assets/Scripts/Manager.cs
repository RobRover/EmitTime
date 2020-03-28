using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
	public static Manager Instance {get; private set;}
    
    [NonSerialized] public float time;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject end_door;
    [SerializeField] public bool end_door_active = true;
    [NonSerialized] public GameObject mainCam;
    [NonSerialized] public bool is_inverted;
    [SerializeField] public MySceneManager sceneManager;
    [NonSerialized] public bool playerCanMove = true; //Do not move during start/end transition

    private void Awake()
    {
    	if(Instance == null && player != null)
    	{
    		Instance = this;
    		time = 0;
    		is_inverted = false;
    	}
    }
}