using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GestureLibraryInput gestureLibraryInput;
    public GestureControl gestureControl;
    public MouseInput mouseInput;
    public TouchInput touchInput;
    public GestureTarget gestureTarget;
    public Metronome metronome;
    public ParticleManager particles;
    public SoundGenerator sounds;

    [Range(0,1)]
    public float missAllowance;

    private float turnFrames;
    private float winThreshhold;
    private int turnScore;
    public bool playerTurn;

    public List<AnimationClip> sequenceGestures;
    public int sequenceBeat;

    void Start()
    {
        sequenceGestures = new List<AnimationClip>();
        sequenceBeat = 0;
    }

    public void StartTurn()
    {        
        if(!playerTurn)
        {
            StartGameBeat();
        }
        else
        {
            StartPlayerBeat();
        }       
         
    }

    public void FinishTurn()
    {
        if(!playerTurn)
        {
            FinishGameBeat();
        }
        else
        {
            FinishPlayerBeat();
        }
    }

    private void StartGameBeat()
    {
        Debug.Log("Tick");
        if(sequenceBeat == 0)
        {
            sequenceGestures.Add(gestureLibraryInput.ChooseAGesture());
        }
        gestureLibraryInput.PlayingAGesture(sequenceGestures[sequenceBeat]);
        touchInput.enabled = false;
    }

    private void FinishGameBeat()
    {
        sequenceBeat++;
        CheckWhoseTurnItIs();
    }

    private void StartPlayerBeat()
    {
        Debug.Log("Tock");
        gestureTarget.Reset();
        gestureLibraryInput.TriggerGesture(sequenceGestures[sequenceBeat]);
        ToggleInput();
    }

    private void FinishPlayerBeat()
    {
        sequenceBeat++;
        ToggleInput();
        turnFrames = gestureTarget.gestureFrames;
        Debug.Log($"frames this turn: {turnFrames}");
        winThreshhold = turnFrames - Mathf.RoundToInt(turnFrames * missAllowance);
        AssessAttemptToCopy();

        CheckWhoseTurnItIs();
    }

    private void AssessAttemptToCopy()
    {
        turnScore = gestureTarget.Score();
        Debug.Log($"win threshhold this turn: {winThreshhold}");
        Debug.Log($"score this turn: {turnScore}");

        if(turnScore < winThreshhold)
        {
            scoreManager.SetScore(sequenceGestures.Count);
            SceneManager.LoadScene("End");
        }

    }

    private void CheckWhoseTurnItIs()
    {
        if(sequenceBeat == sequenceGestures.Count)
        {
            playerTurn = !playerTurn;
            metronome.ChangeTurn();
            gestureControl.FlipTurn();
            sequenceBeat = 0;
        }
    }

    private void ToggleInput()
    {
        #if UNITY_EDITOR
            mouseInput.enabled = !mouseInput.enabled;
        #elif UNITY_ANDROID
            touchInput.enabled = !touchInput.enabled;
        #endif
    }

    public void Emit(Vector3 position)
    {
        if(playerTurn && gestureLibraryInput.isMoving)
        {
            particles.Emit(position, sequenceBeat, 1);
            sounds.Emit(position, sequenceBeat);
        }
    }
}
