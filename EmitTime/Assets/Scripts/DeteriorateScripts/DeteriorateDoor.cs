using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteriorateDoor : MonoBehaviour
{
    public int start_index;
    public int end_index;
    public int start_time;
    public int end_time; 
    public int deactivate_frame;

    public bool needs_button = true;
    
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D box_collider;
    public ButtonScript button;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        box_collider = this.GetComponent<BoxCollider2D>();
    }

    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }

    bool checkPlayerPosition(){
        return Mathf.Floor(Manager.Instance.end_door.transform.position.x) == Mathf.Floor(Manager.Instance.player.transform.position.x) && 
            (Mathf.Floor(Manager.Instance.end_door.transform.position.y) + 2.5 >  Mathf.Floor(Manager.Instance.player.transform.position.y) &&
                Mathf.Floor(Manager.Instance.end_door.transform.position.y) - 2.5 <  Mathf.Floor(Manager.Instance.player.transform.position.y));
            
    }

    // Update is called once per frame
    void Update()
    {
        if (needs_button) {
            Manager.Instance.end_door_active = button.isPressed;
        }
        if (Manager.Instance.time >= start_time) {
            int index = (int) LERP(Manager.Instance.time, start_time, end_time, start_index, end_index);
            
            if (index > end_index) {
                index = end_index;
            }
            
            anim.SetInteger("DoorTime", index);
            if (needs_button) {
                anim.SetBool("ButtonPressed", button.isPressed);
            } else if (checkPlayerPosition()) {
                // If it does not need the button, open the door when the player is near
                anim.SetBool("ButtonPressed", true);
                Manager.Instance.end_door_active = true;
            } else {
                Manager.Instance.end_door_active = false;
            }
        }
    }
}
