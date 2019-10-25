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

    public void FinishTurn()
    {
        gameManager.NextTurn();
        anim.SetTrigger("Play");
    }
}
