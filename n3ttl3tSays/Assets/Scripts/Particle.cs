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
    private int type;

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
        TypeBehaviour();
    }

    public void BeatColour(Material beatColour)
    {
        rend = GetComponentInChildren<Renderer>();
        rend.material = beatColour;
    }

    public void SetParticleType(int beat)
    {
        if(beat < 3)
        {
            type = 1;
        }
        else if(beat < 6)
        {
            type = 2;
        }
        else if(beat < 9)
        {
            type = 3;
        }
        else
        {
            type = 4;
        }
    }

    private void TypeBehaviour()
    {
        switch (type)
        {
            case 1:
                Debug.Log("type 1");
                break;
            case 2:
                Debug.Log("type 2");
                break;
            case 3:
                Debug.Log("type 3");
                break;
            case 4:
                Debug.Log("type 4");
                break;
        }
    }
}
