using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPositions {
    public float v1;
    public float v2;
    public float new_z;
}

public class CameraMovement : MonoBehaviour
{
    public List<CameraPositions> cameraLists;
    public int curr_position;
    
    public float min_y;
    public float max_y;
    
    private int new_pos;
    
    // Start is called before the first frame update
    void Start()
    {
        new_pos = curr_position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        
        if (Manager.Instance.player.transform.position.x < cameraLists[curr_position].v1) {
            if (Manager.Instance.player.transform.position.x < cameraLists[curr_position+1].v2) {
                if (curr_position < cameraLists.Count-1) {
                    curr_position += 1;
                }
            } else {
                new_pos.z = LERP(Manager.Instance.player.transform.position.x, cameraLists[curr_position].v1, cameraLists[curr_position+1].v2, cameraLists[curr_position].new_z, cameraLists[curr_position+1].new_z);
            } 
        } else if (Manager.Instance.player.transform.position.x > cameraLists[curr_position].v2) {
            if (cameraLists[curr_position-1].v1 < Manager.Instance.player.transform.position.x) {
                if (curr_position > 0) {
                    curr_position -= 1;
                }
            } else {
                new_pos.z = LERP(Manager.Instance.player.transform.position.x, cameraLists[curr_position].v2, cameraLists[curr_position-1].v1, cameraLists[curr_position].new_z, cameraLists[curr_position-1].new_z);
            }
            
        }
        
        new_pos.y = Mathf.Clamp(new_pos.y, min_y, max_y);
        
        gameObject.transform.position = new_pos;
        //Debug.Log(cameraLists[curr_position].v1 + "-" + cameraLists[curr_position].v2);
    }
    
    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }
}
