using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{
    public GameObject cube;

    public AnimationClip clip;

    void Awake()
    {
        clip = new AnimationClip();
    }

    public void NewGesture(Vector3 pos)
    {
        MoveCube(pos);
    }

    void MoveCube(Vector3 pos)
    {
        Debug.Log($"before {pos}");
        // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(pos);
        // worldPoint.y = 0;
        Debug.Log($"after {pos}");
        // cube.transform.position = worldPoint;
        cube.transform.position = pos;
    }
}
