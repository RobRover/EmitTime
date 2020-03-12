using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

	[System.Serializable]
	public struct State { 
		public String label;
		public float start; 
		public Sprite leavesSprite;
		public Sprite trunkSprite;
	}

	public State[] states;

	private GameObject leaves;
	private GameObject trunk;
	private GameObject longTrunk;

	private Vector3 leavesScale;
	private Vector3 trunkScale;
	private Vector3 longTrunkScale;

	private Vector3 leavesPos;
	private Vector3 trunkPos;
	private Vector3 longTrunkPos;

	public float factor;
	// Side where the tree is going to fall down; default: right
	public bool inversed = false;
	// Start is called before the first frame update
	void Start()
	{
		leaves = this.transform.GetChild(0).gameObject;
		trunk = this.transform.GetChild(1).gameObject;
		longTrunk = this.transform.GetChild(2).gameObject;


		leavesScale = leaves.transform.localScale;
		trunkScale = trunk.transform.localScale;
		longTrunkScale = trunk.transform.localScale;

		leavesPos = leaves.transform.position;
		trunkPos = trunk.transform.position;
		longTrunkPos = longTrunk.transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		float time = Manager.Instance.time;

		int state = 0;

		for (int i = 0; i < states.Length; i++) 
		{
		  if(time > states[i].start)
			state = i;
		}

		SpriteRenderer leavesSprite = leaves.GetComponent<SpriteRenderer> ();
		SpriteRenderer trunkSprite = trunk.GetComponent<SpriteRenderer> ();

		switch (state)
	    {
	        case 0:
	        	leaves.SetActive(false);
	        	trunk.SetActive(false);
	        	longTrunk.SetActive(false);
	        	leaves.GetComponent<BoxCollider2D>().enabled = false;
	        	trunk.GetComponent<BoxCollider2D>().enabled = false;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = false;
	            break;
	        case 1:
	        	leaves.SetActive(false);
	        	trunk.SetActive(true);
	        	longTrunk.SetActive(false);
	        	leaves.GetComponent<BoxCollider2D>().enabled = false;
	        	trunk.GetComponent<BoxCollider2D>().enabled = false;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = false;
	            trunkSprite.sprite = states[state].trunkSprite;
	            trunk.transform.localScale = trunkScale;
	            trunk.transform.position = trunkPos + new Vector3(0, -1.5f, 0);
	            break;
	        case 2:
	        	leaves.SetActive(true);
	        	trunk.SetActive(true);
	        	longTrunk.SetActive(false);
	        	leaves.GetComponent<BoxCollider2D>().enabled = true;
	        	trunk.GetComponent<BoxCollider2D>().enabled = true;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = false;
	        	transformTree();
	            
	            leavesSprite.sprite = states[state].leavesSprite;
	            trunkSprite.sprite = states[state].trunkSprite;
	            break;
	        case 3:
	        	leaves.SetActive(true);
	        	trunk.SetActive(true);
	        	longTrunk.SetActive(false);
	        	leaves.GetComponent<BoxCollider2D>().enabled = true;
	        	trunk.GetComponent<BoxCollider2D>().enabled = true;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = false;
	            leavesSprite.sprite = states[state].leavesSprite;
	            trunkSprite.sprite = states[state].trunkSprite;
	            break;

	        case 4:
	        	leaves.SetActive(true);
	        	trunk.SetActive(false);
	        	longTrunk.SetActive(true);
	        	leaves.GetComponent<BoxCollider2D>().enabled = true;
	        	trunk.GetComponent<BoxCollider2D>().enabled = false;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = true;
	        	longTrunk.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	        	longTrunk.transform.GetComponent<Rigidbody2D>().mass = 1000;
	            leavesSprite.sprite = states[state].leavesSprite;
	            trunkSprite.sprite = states[state].trunkSprite;
	            break;

	        case 5:
	        	leaves.SetActive(false);
	        	trunk.SetActive(false);
	        	longTrunk.SetActive(true);
	        	leaves.GetComponent<BoxCollider2D>().enabled = false;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = false;
	        	longTrunk.GetComponent<BoxCollider2D>().enabled = true;
	        	longTrunk.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
	            trunkSprite.sprite = states[state].trunkSprite;
	            transformLongTrunk();
	            break;
	    }

	}

	void transformTree(){
		float time = Manager.Instance.time;

		time = time / 10;

		Vector3 scale = new Vector3(time * 0.8f*factor, time * 0.8f*factor, time * 0.8f*factor);

		trunk.transform.localScale = trunkScale + scale;

		scale = new Vector3(time * 0.8f*factor, time * 0.35f*factor, time * 0.8f*factor);
		longTrunk.transform.localScale = longTrunkScale + scale;

		scale = new Vector3(time * 0.4f*factor, time * 0.4f*factor, time * 0.4f*factor);
		leaves.transform.localScale = leavesScale + scale;

		Vector3 pos = new Vector3(0, time * 1f*factor, 0);

		trunk.transform.position = trunkPos + pos;

		pos = new Vector3(time * -0.1f *factor, 0, 0);
		longTrunk.transform.position = longTrunkPos + pos;

		pos = new Vector3(0, time * 3.2f*factor, 0);
		leaves.transform.position = leavesPos + pos;
	}

	void transformLongTrunk(){

		float start_time = states[5].start;
		float end_time = states[6].start;

		float end_angle = (inversed) ? 90 : (-90);

		float time = Manager.Instance.time;

		time = time - start_time;

		time = time / (end_time - start_time);

		float angle = (inversed) ? Mathf.Clamp(time * end_angle, 0, end_angle) : Mathf.Clamp(time * end_angle, end_angle, 0);

		// Reach angle -90; otherwise final angle will be -89, -88, ...
		if((inversed && angle > 87) || (!inversed && angle < -87))
			angle = end_angle;

		longTrunk.transform.localRotation = Quaternion.Euler(0, 0, angle);
		Vector3 pos = new Vector3(0, time * 1.2f, 0) + longTrunkPos;

		longTrunk.transform.position = pos;

	}
}
