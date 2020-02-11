using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float fadePerSecond = 1f;
    private float transformScale;
    private Material material;
    private Renderer rend;
    private Color colour;

    void Start()
    {
        StartCoroutine (CountDown());
        transformScale = fadePerSecond * transform.localScale.x;
        material = GetComponentInChildren<Renderer>().material;
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void Update() 
    {
        var color = material.color;
        material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
        transform.localScale = new Vector3(transform.localScale.x - (transformScale * Time.deltaTime), transform.localScale.y - (transformScale * Time.deltaTime), transform.localScale.z - (transformScale * Time.deltaTime));
    }

    public void BeatColour(Material beatColour)
    {
        rend = GetComponentInChildren<Renderer>();
        rend.material = beatColour;
    }
}
