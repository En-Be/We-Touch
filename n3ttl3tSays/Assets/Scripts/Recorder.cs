using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Recorder : MonoBehaviour
{
    public GestureControl gestureControl;
    public MouseInput mouseInput;
    public TouchInput touchInput;
    public ParticleManager particles;
    public SoundGenerator sounds;

    public Animator anim;

    public int sequenceBeat;

    void Start()
    {
        ToggleInput();
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
        sequenceBeat = 0;
    }

    private void ToggleInput()
    {
        #if UNITY_EDITOR
            mouseInput.enabled = !mouseInput.enabled;
        #elif UNITY_ANDROID
            touchInput.enabled = !touchInput.enabled;
        #endif
    }

    public void StartBeat()
    {        
    }

    public void FinishBeat()
    {
        anim.SetTrigger("Play");
        sequenceBeat++;
        Debug.Log(sequenceBeat);
        if(sequenceBeat == 12)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Emit(Vector3 position)
    {
        particles.Emit(position, sequenceBeat, 1);
        sounds.Emit(position, sequenceBeat);
    }
}
