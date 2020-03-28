﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetriorateAnimationWood : MonoBehaviour
{
    public int start_index;
    public int end_index;
    public int start_time;
    public int end_time; 
    public int deactivate_frame;
    
    protected Animator anim;
    protected Rigidbody2D rb;
    protected BoxCollider2D box_collider;
    // Start is called before the first frame update
    protected void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        box_collider = this.GetComponent<BoxCollider2D>();
        //anim.speed = 0;
        anim.SetInteger("BlockLevel", start_index);
    }
    
    protected float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Manager.Instance.time >= start_time) {
            int index = (int) LERP(Manager.Instance.time, start_time, end_time, start_index, end_index);
            
            if (index > end_index) {
                index = end_index;
            }

            if (index >= deactivate_frame) {
                //rb.enabled = false;
                //rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.gravityScale = 0f;
                box_collider.enabled = false;
            } else {
                //rb.enabled = true;
                //rb.isKinematic = true;
               	rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.gravityScale = 1f;
                box_collider.enabled = true;
            }
            anim.SetInteger("BlockLevel",index);
        }
    }
}
