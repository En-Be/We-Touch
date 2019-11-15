using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public GameManager gameManager;
    private Animator anim;
    public GameObject[] cornerPoints;
    private bool IsChangingTurn;

    void Start()
    {
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
    }

    public void StartBeat()
    {
        if(IsChangingTurn)
        {
            foreach(GameObject point in cornerPoints)
            {
                point.gameObject.transform.Rotate(0,0,90);
            }
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
}
