using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeterioration : MonoBehaviour
{
    private Transform current_pos;
    private Vector3 start_position;
    private Vector3 end_position;
    
    public Transform end_state;
    public int start_time;
    public int end_time;
    // Start is called before the first frame update
    void Start()
    {
        current_pos = this.GetComponent<Transform>();
        start_position = current_pos.position;
        end_position = end_state.position;
    }
    
    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 / f1) / (x2 - x1)) * (x - x1);
    }

    // Update is called once per frame
    void Update()
    {
        float curr_time = Manager.Instance.time;

        if (curr_time > start_time && curr_time < end_time) {
            Vector3 new_position = new Vector3(LERP(curr_time, start_time, end_time, start_position.x, end_position.x),
                                            LERP(curr_time, start_time, end_time, start_position.y, end_position.y),
                                           start_position.z);
            
            Debug.Log(curr_time +"="+start_time+"="+ end_time+"="+new_position);
            current_pos.position = new_position;
            //current_pos.eulerAngles = new_rotation;
            //current_pos.localScale = new_scale;
        }
    }
}
