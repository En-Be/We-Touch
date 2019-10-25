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
            Debug.Log(animTarget.transform.position);
            gestureControl.NewGesture(animTarget.transform.position);
        }
    }

    public void PlayAGesture()
    {
        anim.SetTrigger("Play");
        playing = true;
        StartCoroutine("StopAGesture");
    }

    private IEnumerator StopAGesture()
    {
        yield return new WaitForSeconds(1);
        playing = false;
    }
}
