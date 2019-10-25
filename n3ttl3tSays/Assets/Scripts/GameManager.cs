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
    
    public float difficulty;

    private float startFrames;
    private float finishFrames;
    private float turnFrames;
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
        gestureLibraryInput.PlayAGesture();
        mouseInput.enabled = false;
        touchInput.enabled = false;
    }

    private void StartPlayerTurn()
    {
        Debug.Log("Tock");
        gestureTarget.Reset();
        startFrames = Time.frameCount;
        gestureLibraryInput.PlayAGestureForTracing();
        mouseInput.enabled = true;
        touchInput.enabled = true;
    }

    private void FinishGameTurn()
    {

    }

    private void FinishPlayerTurn()
    {
        finishFrames = Time.frameCount;
        turnFrames = finishFrames - startFrames;
        Debug.Log($"frames this turn: {turnFrames}");
        difficulty = turnFrames - Mathf.RoundToInt(turnFrames * 0.2f);
        AssessAttemptToCopy();
    }

    private void AssessAttemptToCopy()
    {
        turnScore = gestureTarget.Score();
        Debug.Log($"difficulty this turn: {difficulty}");
        Debug.Log($"score this turn: {turnScore}");

        if(turnScore < difficulty)
        {
            SceneManager.LoadScene("End");
        }

    }
}
