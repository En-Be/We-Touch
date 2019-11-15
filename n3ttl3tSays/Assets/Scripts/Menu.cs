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
    }

    public void LoadLevel()
    {
        Debug.Log("pressed");
        if(scoreManager != null)
        {
            Destroy(scoreManager.gameObject);
        }
        SceneManager.LoadScene(goesTo);
    }

    public void LoadInstructions()
    {

    }
}
