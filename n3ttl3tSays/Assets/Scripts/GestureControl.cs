using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{
    public GameObject pointer;

    private Collider pointerCollider;
    private MeshRenderer pointerRenderer;

    void Start()
    {
        pointerCollider = pointer.GetComponent(typeof(Collider)) as Collider;
        pointerRenderer = pointer.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
    }

    public void NewGesture(Vector3 pos)
    {
        
        if(pointer.transform.position == pos)
        {
            pointerRenderer.enabled = false;
            pointerCollider.enabled = false;
        }
        else
        {
            MovePointer(pos);
        }
    }

    void MovePointer(Vector3 pos)
    {
        pointer.transform.position = pos;
        pointerRenderer.enabled = true;
        pointerCollider.enabled = true;
    }
}
