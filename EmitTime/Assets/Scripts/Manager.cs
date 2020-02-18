using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
	public static Manager Instance {get; private set;}
    public float time;
    public GameObject player;
    public bool is_inverted;

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