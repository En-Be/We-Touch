using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTarget : MonoBehaviour
{
    private int score;

    public void Reset()
    {
        score = 0;
    }

    void OnTriggerStay()
    {
        score++;
    }

    public int Score()
    {
        return score;
    }
}
