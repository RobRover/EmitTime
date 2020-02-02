using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject follow;
    private Transform cam_tr;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cam_tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cam_tr.position = new Vector3(follow.transform.position.x, cam_tr.position.y, cam_tr.position.z);
    }
}
