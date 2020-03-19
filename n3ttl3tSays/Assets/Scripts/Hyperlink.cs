using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    public void GoTo()
    {
        Application.OpenURL("https://www.nicholasthe.space/");
    }
}
