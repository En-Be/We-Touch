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
    public bool isMoving;
    public Object[] gestures;
    
    protected AnimatorOverrideController animatorOverrideController;


    void Awake()
    {
        gestureControl = gameObject.GetComponent(typeof(GestureControl)) as GestureControl;
        anim = gameObject.GetComponentInChildren(typeof(Animator)) as Animator;
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

    public void PlayingAGesture(AnimationClip gesture)
    {
        playing = true;

        TriggerGesture(gesture);
        StartCoroutine("StopAGesture");
    }

    public void TriggerGesture(AnimationClip gesture)
    {
        animatorOverrideController["empty"] = gesture;
		anim.runtimeAnimatorController = animatorOverrideController;
        anim.SetTrigger("Play");
    }

    public void SwitchSendingGesturePos()
    {
        isMoving = !isMoving;
        animTargetRenderer.enabled = !animTargetRenderer.enabled;
    }

    public void TurnPointerOn()
    {

    }

    public void TurnPointerOff()
    {

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
