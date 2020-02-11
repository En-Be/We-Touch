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

    public void Emit(Vector3 position, int beat)
    {
        if(beat > currentBeat)
        {
            count++;
            currentBeat = beat;
        }

        if(count > 2)
        {
            count = 0;
        }

        if(beat == 0)
        {
            count = 0;
            currentBeat = 0;
        }

        Debug.Log($"beat is {beat}, currentBeat is {currentBeat}, count is {count}");
        instance = Instantiate(particle, position, transform.rotation);
        instance.transform.localScale = new Vector3(10,10,10);
        instanceScript = instance.GetComponent<Particle>();
        instanceScript.BeatColour(beatColour[count]);

    }
}
