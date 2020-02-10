using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private float fadePerSecond = 1f;
 
    private void Update() 
    {
        var material = GetComponentInChildren<Renderer>().material;
        var color = material.color;
        material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
    }
}
