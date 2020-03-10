using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPositions {
    public float x_min;
    public float x_max;
    public float new_z;
}

public class CameraMovement : MonoBehaviour
{
    public List<CameraPositions> cameraLists;
    public int curr_position;
    private int new_pos;
    
    // Start is called before the first frame update
    void Start()
    {
        new_pos = curr_position;
    }

    // Update is called once per frame
    void Update()
    {
        if (curr_position != new_pos) {
            if (curr_position > new_pos) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, LERP(Manager.Instance.player.transform.position.x, cameraLists[curr_position].x_min, cameraLists[new_pos].x_max, cameraLists[curr_position].new_z, cameraLists[new_pos].new_z));
            } else {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, LERP(Manager.Instance.player.transform.position.x, cameraLists[curr_position].x_max, cameraLists[new_pos].x_min, cameraLists[curr_position].new_z, cameraLists[new_pos].new_z));
            }
        } else {
            if (cameraLists[curr_position].x_min > Manager.Instance.player.transform.position.x) {
                new_pos += 1;
            } else if (cameraLists[curr_position].x_max < Manager.Instance.player.transform.position.x) {
                new_pos -= 1;
            } else {
                curr_position = new_pos;
            }
        }
    }
    
    float LERP(float x, float x1, float x2, float f1, float f2) {
        return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
    }
}
