using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public GameManager gameManager;

    public void FinishTurn()
    {
        gameManager.NextTurn();
    }
}
