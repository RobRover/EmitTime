using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeScale : MonoBehaviour
{
    public string colider_name;
    
    public float new_min;
    public float new_max;
    public float new_value;
    
    public bool new_direction_left;
    
    public float prev_val;
    public float prev_min;
    public float prev_max;
    // Start is called before the first frame update
    void Start()
    {
        // Set block transparent
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = .0f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Change time scale");
        
        if (col.gameObject.name == colider_name) {
            Vector3 rel_pos = col.transform.position - gameObject.transform.position;
            CameraManager cam_man = Manager.Instance.mainCam.GetComponent<CameraManager>();
            
            if ((new_direction_left && (rel_pos.x > 0)) || (!new_direction_left && (rel_pos.x < 0))) {
                //Debug.log();
                prev_min = cam_man.min_time;
                prev_max = cam_man.max_time;
                prev_val = Manager.Instance.time;
                    
                cam_man.min_time = new_min;
                cam_man.max_time = new_max;
                Manager.Instance.time = new_value;
            } else {
                cam_man.min_time = prev_min;
                cam_man.max_time = prev_max;
                Manager.Instance.time = prev_val;
            }
            
            //Debug.Log();
            //Debug.Log(Manager.Instance.time);
        }
        // col.gameObject
    }
}
