using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{
    public GameObject pointer;
    public Recorder recorder;

    private Collider pointerCollider;
    private MeshRenderer pointerRenderer;
    private bool gameTurn = true;

    void Start()
    {
        pointerCollider = pointer.GetComponent(typeof(Collider)) as Collider;
        pointerRenderer = pointer.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
    }

    public void UpdateGesture(Vector3 pos)
    {
        if(pointer.transform.position == pos)
        {
            DisablePointer();
        }
        else
        {
            MovePointer(pos);
        }
    }

    void MovePointer(Vector3 pos)
    {
        if(gameTurn)
        {
            pointerRenderer.enabled = true;
        }
        pointerCollider.enabled = true;
        pointer.transform.position = pos;

        if(recorder != null)
        {
            recorder.AddTurnOnEvent();
            recorder.Emit(pos);
        }
    }

    public void DisablePointer()
    {
        pointerRenderer.enabled = false;
        pointerCollider.enabled = false;
        
        if(recorder != null)
        {
            recorder.AddTurnOffEvent();
        }
    }
    public void FlipTurn()
    {
        gameTurn = !gameTurn;
    }
}
