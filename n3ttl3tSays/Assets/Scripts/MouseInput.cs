using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private GestureControl gestureControl;

    void Awake()
    {
        gestureControl = gameObject.GetComponent(typeof(GestureControl)) as GestureControl;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.y = 0;
            gestureControl.UpdateGesture(worldPoint);
        }
    }

}
