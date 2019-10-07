using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour
{
    public GameObject cube;
    public AnimationClip clip;

    void Awake()
    {
        clip = new AnimationClip();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Began");
            }
            Debug.Log($"Touching at X:{touch.position.x} and Y:{touch.position.y}");
            
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
            worldPoint.y = 0;
            Debug.Log(worldPoint);
            cube.transform.position = worldPoint;

            if(touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch Ended");
            }
        }

    }
}
