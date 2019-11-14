using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GestureLibraryInput gestureLibraryInput;
    public MouseInput mouseInput;
    public TouchInput touchInput;
    public GestureTarget gestureTarget;
    
    [Range(0,1)]
    public float missAllowance;

    private float startFrames;
    private float finishFrames;
    private float turnFrames;
    private float winThreshhold;
    private int turnScore;
    private bool playerTurn;

    void Start()
    {
        
    }

    public void StartTurn()
    {
        if(!playerTurn)
        {
            StartGameTurn();
        }
        else
        {
            StartPlayerTurn();
        }
    }

    public void FinishTurn()
    {
        if(!playerTurn)
        {
            FinishGameTurn();
        }
        else
        {
            FinishPlayerTurn();
        }
        
        playerTurn = !playerTurn;
    }

    private void StartGameTurn()
    {
        Debug.Log("Tick");
        gestureLibraryInput.PlayingAGesture();
        touchInput.enabled = false;
    }

    private void FinishGameTurn()
    {

    }

    private void StartPlayerTurn()
    {
        Debug.Log("Tock");
        gestureTarget.Reset();
        startFrames = Time.frameCount;
        gestureLibraryInput.TriggerGesture();
        ToggleInput();
    }

    private void FinishPlayerTurn()
    {
        ToggleInput();
        finishFrames = Time.frameCount;
        turnFrames = finishFrames - startFrames;
        Debug.Log($"frames this turn: {turnFrames}");
        winThreshhold = turnFrames - Mathf.RoundToInt(turnFrames * missAllowance);
        AssessAttemptToCopy();
    }

    private void AssessAttemptToCopy()
    {
        turnScore = gestureTarget.Score();
        Debug.Log($"win threshhold this turn: {winThreshhold}");
        Debug.Log($"score this turn: {turnScore}");

        if(turnScore < winThreshhold)
        {
            SceneManager.LoadScene("End");
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
}
