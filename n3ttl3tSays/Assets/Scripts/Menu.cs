using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string goesTo;
    public ScoreManager scoreManager;
    public Text scoreText;
    public Animator anim;

    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        scoreManager = FindObjectOfType<ScoreManager>();
        if(scoreManager != null)
        {
            scoreText.text = scoreManager.score.ToString();
        }
        else
        {
            scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        anim = GetComponentInChildren<Animator>();
    }

    public void LoadLevel()
    {
        Debug.Log("pressed");
        anim.SetTrigger("Out");
        if(scoreManager != null)
        {
            Destroy(scoreManager.gameObject);
        }
        // SceneManager.LoadScene(goesTo);
        StartCoroutine("TransitionOut");
    }

    private IEnumerator TransitionOut()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(goesTo);
    }

    public void LoadCredits()
    {
        Debug.Log("pressed");
        anim.SetTrigger("Out");
        StartCoroutine("TransitionToCredits");
    }

    private IEnumerator TransitionToCredits()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Credits");
    }
}
