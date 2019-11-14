using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTarget : MonoBehaviour
{
    private int score;
    public GameObject target;

    public int gestureFrames;
    private Vector3 previousPosition;

    public void Start()
    {
        previousPosition = target.transform.position;
    }

    public void Reset()
    {
        score = 0;
        gestureFrames = 0;
        previousPosition = target.transform.position;
    }

    public void Update()
    {

        if(previousPosition != target.transform.position)
        {
            gestureFrames++;
        }
        previousPosition = target.transform.position;
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
