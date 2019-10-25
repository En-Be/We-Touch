using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GestureLibraryInput gestureLibraryInput;
    public MouseInput mouseInput;
    public TouchInput touchInput;
    
    [Range(0, 100)]
    public int difficulty;

    private int turnScore;
    private bool playerTurn;

    void Awake()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        if(!playerTurn)
        {
            Debug.Log("Tick");
            gestureLibraryInput.PlayAGesture();
            mouseInput.enabled = false;
            touchInput.enabled = false;
        }
        else
        {
            Debug.Log("Tock");
            mouseInput.enabled = true;
            touchInput.enabled = true;
            AssessAttemptToCopy();
        }
        
        playerTurn = !playerTurn;

    }

    private void AssessAttemptToCopy()
    {
        if(turnScore < difficulty)
        {
            SceneManager.LoadScene("End");
        }

    }
}
