using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particle;

    private int count;

    public void Emit(Vector3 position, int level, int beat)
    {
        Debug.Log($"Level is #{level} and beat is#{beat}");
        Instantiate(particle, position, transform.rotation);
    }
}
