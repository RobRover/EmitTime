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
    [NonSerialized] public GameObject camera;
    [NonSerialized] public bool is_inverted;

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