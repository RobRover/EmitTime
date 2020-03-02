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

        scene = SceneManager.GetActiveScene();

        if(Math.Floor(Manager.Instance.end_door.transform.position.x) == Math.Floor(Manager.Instance.player.transform.position.x) 
            && Manager.Instance.end_door.transform.GetChild(0).gameObject.activeSelf 
            && scene.name == "Scene1")
            Application.LoadLevel("Scene2");

        if(Math.Floor(Manager.Instance.end_door.transform.position.x) == Math.Floor(Manager.Instance.player.transform.position.x) 
            && Manager.Instance.end_door.transform.GetChild(0).gameObject.activeSelf 
            && scene.name == "Scene2")
            Application.LoadLevel("Scene1");
    }
}
