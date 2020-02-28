using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleManager particleManager;
    private float fadePerSecond = 1f;
    private float transformScale;
    private Material material;
    private Renderer rend;
    private Color colour;
    private int type;
    private float angle;
    private int upOrDown; // -1 or 1
    private int frames = 0;

    void Start()
    {
        StartCoroutine (CountDown());
        transformScale = fadePerSecond * transform.localScale.x;
        material = GetComponentInChildren<Renderer>().material;
        TypeSetup();
    }

    public void SetManager(ParticleManager pManager)
    {
        particleManager = pManager;
        Debug.Log(particleManager);
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void Update() 
    {
        var color = material.color;
        material.color = new Color(color.r + (5 * Time.deltaTime), color.g + (5 * Time.deltaTime), color.b + (5 * Time.deltaTime), color.a);
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
            type = 3;
        }
        else if(beat < 6)
        {
            type = 2;
        }
        else if(beat < 9)
        {
            type = 1;
        }
        else
        {
            type = 4;
        }
    }

    private void TypeSetup()
    {
        switch (type)
        {
            case 1:
                Debug.Log("type 1");
                break;
            case 2:
                Debug.Log("type 2");
                transform.Rotate(0.0f, 0.0f, ChooseAngle(360), Space.Self);
                upOrDown = ChooseUpOrDown();
                break;
            case 3:
                Debug.Log("type 3");
                transform.Rotate( 0.0f, 0.0f, ChooseAngle(360), Space.Self);
                upOrDown = ChooseUpOrDown();
                break;
            case 4:
                Debug.Log("type 4");
                transform.Rotate( 0.0f, 0.0f, 180, Space.Self);

                break;
        }
    }

    private void TypeBehaviour()
    {
        switch (type)
        {
            case 1:
                transform.localScale = ChooseScale(1);
                break;
            case 2:
                transform.Translate(new Vector3(1, 0, 0) * (Time.deltaTime * (transformScale / 8)));
                transform.Rotate((angle * (transformScale / 4)), 0.0f, 0.0f, Space.Self);
                transform.localScale = ChooseScale(upOrDown);
                break;
            case 3:
                transform.Translate(new Vector3(1, 0, 0) * (Time.deltaTime * (transformScale / 16)));
                transform.localScale = ChooseScale(1);
                frames++;
                if(frames == 6)
                {
                    particleManager.Emit(transform.position, 7, 0);
                    frames = 0;
                }
                break;
            case 4:
                transform.Rotate((angle * (transformScale / 4)), 0.0f, 0.0f, Space.Self);
                transform.Translate(new Vector3(1, 0, 0) * (Time.deltaTime * (transformScale / 2)));
                transform.localScale = ChooseScale(1);
                frames++;
                if(frames == 6)
                {
                    particleManager.Emit(transform.position, 7, 0);
                    frames = 0;
                }
                break;
        }
    }

    private float ChooseAngle(float max)
    {
        float genAngle = 0;
        genAngle = angle + Random.Range(max * -1, max);
        return genAngle;
    }

    private int ChooseUpOrDown()
    {
        return (Random.Range(0, 2) == 0) ? -1 : 1;
    }

    private Vector3 ChooseScale(int upOrDown)
    {
        float difference = transform.localScale.x - (upOrDown * (transformScale * Time.deltaTime));
        Vector3 genScale = new Vector3(difference, difference, difference);
        return genScale;
    }
}
