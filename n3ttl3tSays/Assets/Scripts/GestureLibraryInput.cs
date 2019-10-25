using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureLibraryInput : MonoBehaviour
{
    private GestureControl gestureControl;
    private Animator anim;
    public GameObject animTarget;
    private bool playing;

    void Awake()
    {
        gestureControl = gameObject.GetComponent(typeof(GestureControl)) as GestureControl;
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
    }

    void Update()
    {
        if(playing)
        {
            gestureControl.NewGesture(animTarget.transform.position);
        }
    }

    public void PlayAGesture()
    {
        PlayAGestureForTracing();
        playing = true;
        StartCoroutine("StopAGesture");
    }

    private IEnumerator StopAGesture()
    {
        yield return new WaitForSeconds(2);
        playing = false;
    }

    public void PlayAGestureForTracing()
    {
        anim.SetTrigger("Play");
    }
}
