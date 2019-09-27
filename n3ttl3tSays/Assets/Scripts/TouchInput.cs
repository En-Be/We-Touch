using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log($"Touching at X:{Input.mousePosition.x} and Y:{Input.mousePosition.y}");
        }
    }
}
