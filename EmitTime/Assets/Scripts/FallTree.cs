using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTree : DetriorateAnimationWood
{
    
	public int fall_time;
	public bool inversed;

	private Vector3 treePos;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        treePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        int index = (int) LERP(Manager.Instance.time, base.start_time, base.end_time, base.start_index, base.end_index);
        Debug.Log(index);

        if(index < base.deactivate_frame){
        	base.rb.bodyType = RigidbodyType2D.Static;
        }else if (index >= base.deactivate_frame && index <= fall_time) {
            //rb.enabled = false;
            //rb.isKinematic = false;
            base.rb.constraints = RigidbodyConstraints2D.None;
            base.rb.bodyType = RigidbodyType2D.Dynamic;
            base.rb.gravityScale = 1f;
            base.box_collider.enabled = true;
            transformTrunk(index);
        }else if(index >= fall_time){
        	Debug.Log("Static");
        	base.rb.bodyType = RigidbodyType2D.Static;
        	base.box_collider.enabled = true;
        }
    }

	void transformTrunk(int index){

		float start_time = base.deactivate_frame;
		float end_time = fall_time;

		float end_angle = (inversed) ? 90 : (-90);

		float time = index;

		Debug.Log("Time Manager: " + time);

		time = time - start_time;

		time = time / (end_time - start_time);

		Debug.Log("Time: " + time);

		float angle = (inversed) ? Mathf.Clamp(time * end_angle, 0, end_angle) : Mathf.Clamp(time * end_angle, end_angle, 0);

		// Reach angle -90; otherwise final angle will be -89, -88, ...
		if((inversed && angle > 87) || (!inversed && angle < -87))
			angle = end_angle;

		transform.localRotation = Quaternion.Euler(0, 0, angle);

		float x_pos = (inversed) ? time * -10f : time * 7f;
		float y_pos = (inversed) ? time * -5f : time * -7.5f;

		if((inversed && angle < 20) || (!inversed && angle > -20))  
			y_pos = 0;

		Vector3 pos = new Vector3(x_pos,  y_pos, 0)+ treePos;

		transform.position = pos;

	}
}