using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;
using UnityEditor;

public class Recorder : MonoBehaviour
{
    public GestureControl gestureControl;
    public MouseInput mouseInput;
    public TouchInput touchInput;
    public ParticleManager particles;
    public SoundGenerator sounds;
    public GameObject pointer;

    public Animator anim;

    public int sequenceBeat;
    public AnimationClip clip;
    public GameObjectRecorder m_Recorder;
    
    void Start()
    {
        ToggleInput();
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
        sequenceBeat = 0;
        StartBeat();
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
        // Create recorder and record the script GameObject.
        m_Recorder = new GameObjectRecorder(pointer);

        // Bind all the Transforms on the GameObject and all its children.
        m_Recorder.BindComponent(transform);

        clip = new AnimationClip();
        clip.name = $"clip_{sequenceBeat}_{System.DateTime.Now.ToString("HH-mm-ss")}";

    }

    public void Emit(Vector3 position)
    {
        particles.Emit(position, sequenceBeat, 1);
        sounds.Emit(position, sequenceBeat);
        
        m_Recorder.TakeSnapshot(Time.deltaTime);
    }

    public void FinishBeat()
    {        
        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            m_Recorder.SaveToClip(clip);
            AssetDatabase.CreateAsset(clip, $"Assets/Resources/Gestures/{clip.name}.anim");
        }
        
        sequenceBeat++;
        if(sequenceBeat == 12)
        {
            SceneManager.LoadScene("Menu");
        }
        anim.SetTrigger("Play");
    }
}
