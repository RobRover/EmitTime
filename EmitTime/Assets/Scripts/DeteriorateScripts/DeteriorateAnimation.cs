using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteriorateAnimation : MonoBehaviour
{
    public int start_index;
    public int end_index;
    public int start_time;
    public int end_time;
    public string animation_name = "BreakLevel";

    public bool set_debug = false;
    
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.SetInteger(animation_name, start_index);
        //anim.speed = 0;
    }
    
    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (set_debug) {
            Debug.Log(Manager.Instance.time +"-"+start_time+"-"+ end_time);
        }*/
        if (( (start_time < end_time) && Manager.Instance.time >= start_time && Manager.Instance.time <= end_time) || 
            ( (start_time > end_time) && Manager.Instance.time >= end_time && Manager.Instance.time <= start_time)) {
            int index = (int) LERP(Manager.Instance.time, start_time, end_time, start_index, end_index);

            if (set_debug) {
                Debug.Log(anim.GetInteger(animation_name) + "-" + index + "+" + Manager.Instance.time);
            }

            // Clamp the Index depending on the scale
            if ((start_index > end_index) && (index > start_index)) {
                index = start_index;
            } else if ((start_index < end_index) && (index > end_index)) {
                index = end_index;
            }
            
            anim.SetInteger(animation_name, index);
        }
    }
}
