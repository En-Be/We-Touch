using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleParticles : MonoBehaviour
{
    public GameObject particle;
    public int arraySize;
    public Color[] colours;
    private GameObject instance;
    // private Material material;
    public bool isStarter;
    public float rotateAmount = 0;
    public float translateAmount = 3;

    void Start()
    {
        if(isStarter)
        {
            // Emit();
            // Destroy(gameObject);
            StartCoroutine("CountDown");
        }
        else
        {
            // StartCoroutine (CountDown());
        }
        // material = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        // var color = material.color;
        // material.color = new Color(color.r + (5 * Time.deltaTime), color.g + (5 * Time.deltaTime), color.b + (5 * Time.deltaTime), color.a);
        if(!isStarter)
        {
            gameObject.transform.Rotate(0.0f, 0.0f, rotateAmount);
            transform.Translate(new Vector3(translateAmount, 0, 0) * (Time.deltaTime));
        }
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.25f);
        Emit();
        StartCoroutine("CountDown");
        // Destroy(gameObject);
    }

    private void Emit()
    {
        float angle = 0.0f;
        float rotateAmount = Random.Range(-3, 3);
        float translateAmount = Random.Range(0.5f, 2);
        float scale = Random.Range(0.1f, 1);
        // Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        Color color = colours[Random.Range(0, colours.Length)];
        for(int i = 1; i <= arraySize; i++)
        {
            angle += 360 / arraySize;
            instance = Instantiate(particle, transform.position, Quaternion.Euler(90, 0, angle));
            instance.transform.localScale = new Vector3 (scale, scale, scale);
            TitleParticles particleScript = instance.GetComponent<TitleParticles>();
            particleScript.isStarter = false;
            particleScript.rotateAmount = rotateAmount;
            particleScript.translateAmount = translateAmount;
            instance.GetComponent<SpriteRenderer>().material.color = color;

        }
    }
}
