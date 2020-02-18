using System.Collections;
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

        if(Manager.Instance.player.transform.position.x < 25f && scene.name == "Scene1")
            Application.LoadLevel("Scene2");

        Debug.Log("Pos x : " + Manager.Instance.player.transform.position.x);
    }
}
