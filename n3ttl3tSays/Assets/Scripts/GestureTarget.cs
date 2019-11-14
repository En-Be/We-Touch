using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTarget : MonoBehaviour
{
    private int score;
    public GameObject target;

    public int gestureFrames;
    private Vector3 previousPosition;

    public void Reset()
    {
        score = 0;
        gestureFrames = 0;
    }

    public void Update()
    {
        if(previousPosition == target.transform.position)
        {
            Debug.Log("Not moving");
        }
        else
        {
            gestureFrames++;
            Debug.Log(gestureFrames);
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
