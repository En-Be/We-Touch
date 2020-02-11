using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public GameManager gameManager;
    public Camera cam;
    public Color black;
    public Color white;
    private Animator anim;
    private bool IsChangingTurn;

    void Start()
    {
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
    }

    public void StartBeat()
    {
        if(IsChangingTurn)
        {
            ChangeBackgroundColour();
            IsChangingTurn = false;
        }

        gameManager.StartTurn();
    }

    public void FinishBeat()
    {
        gameManager.FinishTurn();
        anim.SetTrigger("Play");
    }

    public void ChangeTurn()
    {
        IsChangingTurn = true;
    }

    private void ChangeBackgroundColour()
    {
        if (cam.backgroundColor == black)
        {
            cam.backgroundColor = white;
        }
        else
        {
            cam.backgroundColor = black;
        }
    }
}
