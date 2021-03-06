﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteriorateTransform : MonoBehaviour
{
    private Transform current_pos;

    private Vector3 start_scale;
    public Vector3 end_scale;

    private float start_rotation;
    public float end_rotation;
    
    public int start_time;
    public int end_time;
    // Start is called before the first frame update
    void Start()
    {
        current_pos = this.GetComponent<Transform>();
        start_scale = current_pos.localScale;
        start_rotation = current_pos.eulerAngles.z;
    }
    
    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curr_time = Manager.Instance.time;

        if ((curr_time > start_time && curr_time < end_time) || (curr_time < start_time && curr_time > end_time)) {

            Vector3 new_scale =  new Vector3(LERP(curr_time, start_time, end_time, start_scale.x, end_scale.x),
                                            LERP(curr_time, start_time, end_time, start_scale.y, end_scale.y),
                                            LERP(curr_time, start_time, end_time, start_scale.z, end_scale.z));

            if (end_rotation == 0) {
                 Vector3 new_rotation = new Vector3(0, 0,
                                            LERP(curr_time, start_time, end_time, start_rotation, end_rotation));
                current_pos.eulerAngles = new_rotation;
            }
           
            current_pos.localScale = new_scale;
        }
    }
}
