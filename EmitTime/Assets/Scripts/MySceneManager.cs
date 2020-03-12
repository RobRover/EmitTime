using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    static MySceneManager Instance;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
            GameObject.Destroy(gameObject);
        else{
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(Manager.Instance.end_door == null)
            return;

        scene = SceneManager.GetActiveScene();

        if(checkPlayerPosition()
            && Manager.Instance.end_door.transform.GetChild(0).gameObject.activeSelf 
            && scene.name == "Scene1")
            Application.LoadLevel("Scene2");

        if(checkPlayerPosition()
            && Manager.Instance.end_door.transform.GetChild(0).gameObject.activeSelf 
            && scene.name == "Scene2")
            Application.LoadLevel("Scene1");

    }

    //Check if X position of the player is the same as the X position of the door; also check the Y of the player is in the range of the door (door.Y - 2.5, door.Y + 2.5)
    bool checkPlayerPosition(){
        return Math.Floor(Manager.Instance.end_door.transform.position.x) == Math.Floor(Manager.Instance.player.transform.position.x) && 
            (Math.Floor(Manager.Instance.end_door.transform.position.y) + 2.5 >  Math.Floor(Manager.Instance.player.transform.position.y) &&
                Math.Floor(Manager.Instance.end_door.transform.position.y) - 2.5 <  Math.Floor(Manager.Instance.player.transform.position.y));
            
    }
}
