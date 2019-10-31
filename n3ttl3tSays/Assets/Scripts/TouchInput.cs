using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private GestureControl gestureControl;

    void Awake()
    {
        gestureControl = gameObject.GetComponent(typeof(GestureControl)) as GestureControl;
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
            gestureControl.UpdateGesture(worldPoint);

            if(touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch Ended");
            }
        }
        

    }
}
