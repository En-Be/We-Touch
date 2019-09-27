using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject cube;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log($"Touching at X:{Input.mousePosition.x} and Y:{Input.mousePosition.y}");
            
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.y = 0;
            Debug.Log(worldPoint);
            cube.transform.position = worldPoint;
        }
    }
}
