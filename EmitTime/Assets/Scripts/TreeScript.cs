using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

	[System.Serializable]
	public struct State { 
		public float start; 
		public Sprite leavesSprite;
		public Sprite trunkSprite;
	}

	private SpriteRenderer defaultLeavesSprite;
	private SpriteRenderer defaultTrunkSprite;

	public State[] states;

	private GameObject leaves;
	private GameObject trunk;

	private Vector3 leavesScale;
	private Vector3 trunkScale;

	private Vector3 leavesPos;
	private Vector3 trunkPos;

	// Start is called before the first frame update
	void Start()
	{
		leaves = this.transform.GetChild (0).gameObject;
		trunk = this.transform.GetChild (1).gameObject;

		leavesScale = leaves.transform.localScale;
		trunkScale = trunk.transform.localScale;

		leavesPos = leaves.transform.position;
		trunkPos = trunk.transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		if(states.Length != 4)
			return;

		float time = Manager.Instance.time;

		int state = 0;

		if(time > states[0].start)
			state = 0;
		if(time > states[1].start)
			state = 1;
		if(time > states[2].start)
			state = 2;
		if(time > states[3].start)
			state = 3;


		SpriteRenderer leavesSprite = leaves.GetComponent<SpriteRenderer> ();
		SpriteRenderer trunkSprite = trunk.GetComponent<SpriteRenderer> ();

		switch (state)
	    {
	        case 0:
	        	leaves.active = false;
	        	trunk.active = false;
	        	leaves.GetComponent<BoxCollider2D>().enabled = false;
	        	trunk.GetComponent<BoxCollider2D>().enabled = false;
	            break;
	        case 1:
	        	leaves.active = false;
	        	trunk.active = true;
	        	leaves.GetComponent<BoxCollider2D>().enabled = false;
	        	trunk.GetComponent<BoxCollider2D>().enabled = false;
	            trunkSprite.sprite = states[state].trunkSprite;
	            trunk.transform.localScale = trunkScale;
	            trunk.transform.position = trunkPos + new Vector3(0, -1.5f, 0);
	            break;
	        case 2:
	        	leaves.active = true;
	        	trunk.active = true;
	        	leaves.GetComponent<BoxCollider2D>().enabled = true;
	        	trunk.GetComponent<BoxCollider2D>().enabled = true;
	            transformTree();
	            leavesSprite.sprite = states[state].leavesSprite;
	            trunkSprite.sprite = states[state].trunkSprite;
	            break;
	        case 3:
	        	leaves.active = true;
	        	trunk.active = true;
	        	leaves.GetComponent<BoxCollider2D>().enabled = true;
	        	trunk.GetComponent<BoxCollider2D>().enabled = true;
	            leavesSprite.sprite = states[state].leavesSprite;
	            trunkSprite.sprite = states[state].trunkSprite;
	            break;
	    }

	}

	void transformTree(){
		float time = Manager.Instance.time;

		time = time / 10;

		Vector3 scale = new Vector3(time * 0.8f, time * 0.8f, time * 0.8f);

		trunk.transform.localScale = trunkScale + scale;

		scale = new Vector3(time * 0.4f, time * 0.4f, time * 0.4f);
		leaves.transform.localScale = leavesScale + scale;

		Vector3 pos = new Vector3(0, time * 1.15f, 0);

		trunk.transform.position = trunkPos + pos;

		pos = new Vector3(0, time * 3.5f, 0);
		leaves.transform.position = leavesPos + pos;
	}

}
