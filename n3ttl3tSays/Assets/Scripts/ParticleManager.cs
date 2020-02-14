using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particle;
    public Material[] beatColour;
    public GameObject instance;
    public Particle instanceScript;

    private int count = 0;
    private int currentBeat = 0;
    private float size = 3;

    public void Emit(Vector3 position, int beat)
    {
        if(beat > currentBeat)
        {
            count++;
            currentBeat = beat;
            size *= 2.5f;
        }

        if(count > 2)
        {
            count = 0;
            size = 3f;
        }

        if(beat == 0)
        {
            count = 0;
            currentBeat = 0;
            size = 3f;
        }

        Debug.Log($"beat is {beat}, currentBeat is {currentBeat}, count is {count}");
        instance = Instantiate(particle, position, transform.rotation);
        instance.transform.localScale = new Vector3(size,size,size);
        instanceScript = instance.GetComponent<Particle>();
        instanceScript.SetManager(this);
        instanceScript.BeatColour(beatColour[count]);
        instanceScript.SetParticleType(beat);
    }
}
