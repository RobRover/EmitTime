using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    private Vector2 move_delta;
    private float jump_len_count;
    private bool jump_trigger;
    private bool can_jump;
    
    public const float JUMP_LEN = 1.10f;
    public BoxCollider2D bottom_colider;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        can_jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (can_jump) {
                jump_trigger = true;
                jump_len_count = 0f;
                can_jump = false;
            } 
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            move_delta.x = (float) 3.05f;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            move_delta.x = (float) -3.05f;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
            move_delta.x = (float) 0.0f;
        }
    }
    
    public static float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + (x-x1)*((f2 - f1)/(x2-x1 + 0.001f));
    }

    
    void FixedUpdate() {
        if (jump_trigger) {
            float adjusted_displacement = LERP(jump_len_count, 0f, JUMP_LEN, 0.5f, (Mathf.PI/4) * 3.5f);
            move_delta.y = (float) 7f * Mathf.Sin( adjusted_displacement );
            jump_len_count += Time.fixedDeltaTime;
                        
            if (jump_len_count >= JUMP_LEN) {
                jump_trigger = false;
                move_delta.y = 0f;
            }
        }
        rb.MovePosition(rb.position + move_delta * Time.fixedDeltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Floor") {
            jump_trigger = false;
            move_delta.y = 0f;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        foreach(ContactPoint2D contact in col.contacts) {
            if (contact.collider.tag == "Floor") {
                can_jump = true;
            }
        }
    }
    
   
}
