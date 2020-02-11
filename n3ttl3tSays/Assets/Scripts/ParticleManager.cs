using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particle;
    public Material[] beatColour;
    public GameObject instance;
    public Particle instanceScript;

    private int count;

    public void Emit(Vector3 position, int level, int beat)
    {
        Debug.Log($"Level is {level} and beat is {beat}");
        instance = Instantiate(particle, position, transform.rotation);
        instance.transform.localScale = new Vector3(10,10,10);
        instanceScript = instance.GetComponent<Particle>();
        instanceScript.BeatColour(beatColour[beat]);
    }
}
