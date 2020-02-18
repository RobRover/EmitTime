using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeteriorateScript : MonoBehaviour
{

  [System.Serializable]
  public struct State { 
    public float start; 
    public Sprite sprite;
  }

  private SpriteRenderer defaultSprite;

  public State[] states;

    // Start is called before the first frame update
  void Start()
  {
    defaultSprite = this.GetComponent<SpriteRenderer> ();
  }

    // Update is called once per frame
  void Update()
  {
    Sprite renderSprite = null;

    float time = Manager.Instance.time;

    foreach (State s in states)
    {
      if(time >= s.start)
      renderSprite = s.sprite;
    }

    if(renderSprite == null){
      if(states.Length > 0){
        State first = states[0];
        State last = states[states.Length - 1];

        if(time < first.start)
          renderSprite = first.sprite;
        else
          renderSprite = last.sprite;
        }else
          renderSprite = defaultSprite.sprite;
      }
      

      defaultSprite.sprite = renderSprite;
    }
  }
