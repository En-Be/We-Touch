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
    private bool isMoving;
    public Object[] gestures;
    
    protected AnimatorOverrideController animatorOverrideController;


    void Awake()
    {
        gestureControl = gameObject.GetComponent(typeof(GestureControl)) as GestureControl;
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
        gestures = Resources.LoadAll("Gestures", typeof(AnimationClip));
        
        animatorOverrideController = new AnimatorOverrideController();
		animatorOverrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
		
    }
    
    void Update()
    {
        if(playing && isMoving)
        {
            gestureControl.UpdateGesture(animTarget.transform.position);
        }
    }

    public void PlayingAGesture()
    {
        playing = true;
        animatorOverrideController["SampleA"] = ChooseAGesture();
		anim.runtimeAnimatorController = animatorOverrideController;
        TriggerGesture();
        StartCoroutine("StopAGesture");
    }

    public void TriggerGesture()
    {
        anim.SetTrigger("Play");
    }

    public void SwitchSendingGesturePos()
    {
        isMoving = !isMoving;
        animTargetRenderer.enabled = !animTargetRenderer.enabled;
    }

    public AnimationClip ChooseAGesture()
    {
        AnimationClip gesture = (AnimationClip)gestures[Random.Range(0, gestures.Length)];
        return gesture;
    }
    
    private IEnumerator StopAGesture()
    {
        yield return new WaitForSeconds(2);
        playing = false;
    }

}
