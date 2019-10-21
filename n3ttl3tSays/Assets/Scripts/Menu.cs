using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public string goesTo;

    public void LoadLevel()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(goesTo);
    }
}
