using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTime : MonoBehaviour
{
    public int start_index;
    public int end_index;
    public int start_time;
    public int end_time;
    public string animation_name;
    public ButtonScript button;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        //anim.speed = 0;
    }
    
    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.time >= start_time) {
            int index = (int) LERP(Manager.Instance.time, start_time, end_time, start_index, end_index);
            
            if (index > end_index) {
                index = end_index;
            }
            //anim[animation_name].time = index;
            Debug.Log(index);
            //anim.Play(animation_name, 0, index);
            anim.SetBool("ButtonPressed", button.isPressed);
        }
    }
}
