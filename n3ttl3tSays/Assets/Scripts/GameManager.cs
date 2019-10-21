using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Range(0, 100)]
    public int difficulty;

    private int turnScore;
    private bool playerTurn;

    public void NextTurn()
    {
        if(!playerTurn)
        {
            Debug.Log("Tick");
        }
        else
        {
            Debug.Log("Tock");
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
