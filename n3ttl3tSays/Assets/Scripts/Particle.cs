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
}
