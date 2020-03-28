using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    [SerializeField] public Animator transition;

    [SerializeField] public float transitionTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance.end_door == null)
            return;
        if(checkPlayerPosition() && Manager.Instance.end_door_active)
            LoadNextLevel();


        //Do not move during start/end transition 
        if(Manager.Instance.playerCanMove && 
            (this.transition.GetCurrentAnimatorStateInfo(0).IsName("Crossfade_Start") || this.transition.GetCurrentAnimatorStateInfo(0).IsName("Crossfade_End")))
            Manager.Instance.playerCanMove = false;
        else if(!Manager.Instance.playerCanMove && 
            !(this.transition.GetCurrentAnimatorStateInfo(0).IsName("Crossfade_Start") || this.transition.GetCurrentAnimatorStateInfo(0).IsName("Crossfade_End")))
            Manager.Instance.playerCanMove = true;

    }

    //Check if X position of the player is the same as the X position of the door; also check the Y of the player is in the range of the door (door.Y - 2.5, door.Y + 2.5)
    bool checkPlayerPosition(){
        return Math.Floor(Manager.Instance.end_door.transform.position.x) == Math.Floor(Manager.Instance.player.transform.position.x) && 
            (Math.Floor(Manager.Instance.end_door.transform.position.y) + 2.5 >  Math.Floor(Manager.Instance.player.transform.position.y) &&
                Math.Floor(Manager.Instance.end_door.transform.position.y) - 2.5 <  Math.Floor(Manager.Instance.player.transform.position.y));
            
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1 ) % SceneManager.sceneCountInBuildSettings;
        StartCoroutine(LoadLevel(nextSceneIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void ResetCurrentLevel(){
        StartCoroutine(ResetLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator ResetLevel(int levelIndex)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator WaitASecond(){
        yield return new WaitForSeconds(1);
    }
}
