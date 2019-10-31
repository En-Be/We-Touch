using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureLibraryInput : MonoBehaviour
{
    private GestureControl gestureControl;
    private Animator anim;
    public GameObject animTarget;
    public MeshRenderer animTargetRenderer;
    private bool playing;
    public Object[] gestures;
    
    protected AnimatorOverrideController animatorOverrideController;


    void Awake()
    {
        gestureControl = gameObject.GetComponent(typeof(GestureControl)) as GestureControl;
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
        gestures = Resources.LoadAll("Gestures", typeof(AnimationClip));
        // foreach (var t in gestures)
        // {
        //     Debug.Log(t.name);
        // }
        
        animatorOverrideController = new AnimatorOverrideController();
		animatorOverrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
		
    }
    
    void Update()
    {
        if(playing)
        {
            gestureControl.UpdateGesture(animTarget.transform.position);
        }
    }

    public void PlayingAGesture()
    {
        animTargetRenderer.enabled = false;
        animatorOverrideController["SampleA"] = ChooseAGesture();
		anim.runtimeAnimatorController = animatorOverrideController;
        TriggerGesture();
        playing = true;
        StartCoroutine("StopAGesture");
    }

    public void TriggerGesture()
    {
        anim.SetTrigger("Play");
    }

    public AnimationClip ChooseAGesture()
    {
        AnimationClip gesture = (AnimationClip)gestures[Random.Range(0, gestures.Length)];
        return gesture;
    }
    
    private IEnumerator StopAGesture()
    {
        yield return new WaitForSeconds(2);
        animTargetRenderer.enabled = true;
        playing = false;
    }

}
