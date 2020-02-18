using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Text time_text;    

    private Vector3 prev_pos;

    void Start()
    {
        prev_pos = new Vector3(0,0,0);
    }

    void Update()
    {
        //Don't have prev pos
        bool has_moved;

        if(prev_pos == new Vector3(0,0,0))
            has_moved = false;
        else if(prev_pos.x == Manager.Instance.player.transform.position.x){
            has_moved = false;
        }else
            has_moved = true;

        float x_diff = Manager.Instance.player.transform.position.x - prev_pos.x;

        if(has_moved && !Manager.Instance.is_inverted)
            Manager.Instance.time += x_diff; 
        else if(has_moved && Manager.Instance.is_inverted)
            Manager.Instance.time -= x_diff;
        
        //time_text.text = "Time: " + Math.Floor(Manager.Instance.time).ToString();

        Debug.Log(Manager.Instance.time);
        prev_pos = Manager.Instance.player.transform.position;

        if(Camera.main != null)
        {
            Vector3 camera_pos = Camera.main.transform.position;
            camera_pos.x = Manager.Instance.player.transform.position.x;
            //camera_pos.y = Manager.Instance.player.transform.position.y;
            //camera_pos.y = Manager.Instance.player.transform.position.y + 3;
            Camera.main.transform.position = camera_pos;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && Camera.main != null){

            Manager.Instance.is_inverted = !Manager.Instance.is_inverted;

            Camera.main.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            Vector3 camera_pos = Camera.main.transform.position;
            camera_pos.z *= -1;
            Camera.main.transform.position = camera_pos;
        }
    }
}
