using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public GameManager gameManager;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
    }

    public void StartTurn()
    {
        gameManager.StartTurn();
    }

    public void FinishTurn()
    {
        gameManager.FinishTurn();
        anim.SetTrigger("Play");
    }
}
