using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Manager.Instance.player.transform.position.x - 1, Manager.Instance.player.transform.position.y + 2, Manager.Instance.player.transform.position.z);
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && Camera.main != null){

            Manager.Instance.is_inverted = !Manager.Instance.is_inverted;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1,
                                                          gameObject.transform.localScale.y,
                                                          gameObject.transform.localScale.z);
            /*Camera.main.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            Vector3 camera_pos = Camera.main.transform.position;
            camera_pos.z *= -1;
            Camera.main.transform.position = camera_pos;*/
        }
    }
}
